using N_Layer_App_EF_Template.Business.DTOs.ClaimDTOs;
using N_Layer_App_EF_Template.Business.DTOs.RoleDTOs;
using N_Layer_App_EF_Template.Business.Mappings.Abstracts;
using N_Layer_App_EF_Template.Business.ServiceResults.Abstracts;
using N_Layer_App_EF_Template.Business.Services.Commons;
using N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;
using N_Layer_App_EF_Template.DataAccess.UnitOfWorks.Abstracts;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Concretes;

public class RoleService : BaseService, IRoleService
{
    public RoleService(IUnitOfWork unitOfWork, IAutoMapper autoMapper) : base(unitOfWork, autoMapper)
    { }

    public async Task<IServiceResult> AddClaimsToRoleAsync(long roleId, IEnumerable<ClaimDto> claimDtos)
    {
        var role = await _unitOfWork.GetRepository<Role, long>()
                                         .GetAsync(roleId, isTracking: true, includeProperties: "Claims");

        if (role is null)
            return NotFound("Role not found.");

        if (claimDtos is null || !claimDtos.Any())
            return BadRequest("Claims cannot be empty.");

        var claims = _autoMapper.Map<Claim, ClaimDto>(claimDtos);

        foreach (var claim in claims)
            if (!role.Claims.Any(c => c.Name == claim.Name))
                role.Claims.Add(claim);

        await _unitOfWork.CommitAsync();

        return Success();
    }

    public async Task<IServiceResult> AddClaimToRoleAsync(long roleId, ClaimDto claimDto)
    {
        var role = await _unitOfWork.GetRepository<Role, long>()
            .GetAsync(roleId, isTracking: true, includeProperties: "Claims");

        if (role is null)
            return NotFound("Role not found.");

        if (claimDto is null)
            return BadRequest("Claim cannot be null.");

        var claim = _autoMapper.Map<Claim, ClaimDto>(claimDto);

        if (role.Claims.Any(c => c.Name == claim.Name))
            return BadRequest($"Claim with name {claim.Name} already exists in the role.");

        role.Claims.Add(claim);
        await _unitOfWork.CommitAsync();

        return Success();
    }

    public async Task<IServiceResult> CreateAsync(RoleDto roleDto)
    {
        var role = _autoMapper.Map<Role, RoleDto>(roleDto);

        var existingRole = await _unitOfWork.GetRepository<Role, long>().GetAllAsync(r => r.Name == role.Name, false);
        if (existingRole.Any())
            return BadRequest($"Role with name {role.Name} already exists.");

        await _unitOfWork.GetRepository<Role, long>().AddAsync(role);
        await _unitOfWork.CommitAsync();

        return Created(role);
    }

    public async Task<IServiceResult> DeleteAsync(long roleId)
    {
        var role = await _unitOfWork.GetRepository<Role, long>()
                                     .GetAsync(roleId, isTracking: true);

        if (role is null)
            return NotFound("Role not found.");

        await _unitOfWork.GetRepository<Role, long>().DeleteAsync(role);
        await _unitOfWork.CommitAsync();

        return Success();
    }

    public async Task<IServiceResult> GetAllAsync()
    {
        var roles = await _unitOfWork.GetRepository<Role, long>()
                                     .GetAllAsync(isTracking: false);

        var roleDtos = _autoMapper.Map<RoleDto, Role>(roles.ToList());
        return Success(roleDtos);
    }

    public async Task<IServiceResult> GetAllByUserId(long userId)
    {
        var user = await _unitOfWork.GetRepository<User, long>()
                                     .GetAsync(userId, isTracking: false, includeProperties: "Roles");

        if (user is null)
            return NotFound("User not found.");

        var roleDtos = _autoMapper.Map<RoleDto, Role>(user.Roles);

        return Success(roleDtos);
    }

    public async Task<IServiceResult> GetAsync(long roleId)
    {
        var role = await _unitOfWork.GetRepository<Role, long>()
                                     .GetAsync(roleId, isTracking: false);

        if (role is null)
            return NotFound("Role not found.");

        var roleDto = _autoMapper.Map<RoleDto, Role>(role);

        return Success(roleDto);
    }

    public async Task<IServiceResult> GetClaimsByRoleIdAsync(long roleId)
    {
        var role = await _unitOfWork.GetRepository<Role, long>()
                                     .GetAsync(roleId, isTracking: false, includeProperties: "Claims");

        if (role is null)
            return NotFound("Role not found.");

        var claimDtos = _autoMapper.Map<ClaimDto, Claim>(role.Claims);
        return Success(claimDtos);
    }

    public async Task<IServiceResult> RemoveClaimFromRoleAsync(long roleId, long claimId)
    {
        var role = await _unitOfWork.GetRepository<Role, long>().GetAsync(roleId);
        if (role is null)
            return NotFound("Role not found.");

        var claimToRemove = role.Claims.FirstOrDefault(c => c.Id == claimId);
        if (claimToRemove is null)
            return NotFound("Claim not found in the specified role.");

        role.Claims.Remove(claimToRemove);
        await _unitOfWork.CommitAsync();

        var roleDto = _autoMapper.Map<RoleDto, Role>(role);
        return Success(roleDto);
    }

    public async Task<IServiceResult> RemoveClaimsFromRoleAsync(long roleId, IEnumerable<long> claimIds)
    {
        var role = await _unitOfWork.GetRepository<Role, long>().GetAsync(roleId);
        if (role is null)
            return NotFound("Role not found.");

        var claimsToRemove = role.Claims.Where(c => claimIds.Contains(c.Id)).ToList();
        if (!claimsToRemove.Any())
            return NotFound("No matching claims found in the specified role.");

        foreach (var claim in claimsToRemove)
            role.Claims.Remove(claim);


        await _unitOfWork.CommitAsync();

        var roleDto = _autoMapper.Map<RoleDto, Role>(role);
        return Success(roleDto);
    }

    public async Task<IServiceResult> UpdateAsync(RoleDto roleDto)
    {
        var existingRole = await _unitOfWork.GetRepository<Role, long>().GetAsync(roleDto.Id);
        if (existingRole is null)
            return NotFound("Role not found.");

        existingRole.Name = roleDto.Name;
        existingRole.Description = roleDto.Description;

        if (roleDto.Claims != null)
        {
            existingRole.Claims.Clear();
            foreach (var claimDto in roleDto.Claims)
            {
                var claim = _autoMapper.Map<Claim, ClaimDto>(claimDto);
                existingRole.Claims.Add(claim);
            }
        }

        await _unitOfWork.CommitAsync();

        var updatedRoleDto = _autoMapper.Map<RoleDto, Role>(existingRole);
        return Success(updatedRoleDto);
    }
}
