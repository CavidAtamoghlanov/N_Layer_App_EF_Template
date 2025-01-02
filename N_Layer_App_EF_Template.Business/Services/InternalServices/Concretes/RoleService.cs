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

    public async Task<IServiceResult> AddClaimsToRoleAsync(long roleId, IEnumerable<long> claimIds)
    {
        if (claimIds == null || !claimIds.Any())
            return BadRequest("Claim IDs cannot be null or empty.");

        var role = await _unitOfWork.GetRepository<Role, long>()
                                     .GetAsync(roleId, isTracking: true, includes: "Claims");
        if (role is null)
            return NotFound("Role not found.");

        var claims = await _unitOfWork.GetRepository<Claim, long>().FindAsync(c => claimIds.Contains(c.Id));

        if (!claims.Any())
            return BadRequest("No valid claims found.");

        var existingClaimIds = role.Claims.Select(c => c.Id).ToHashSet();
        var newClaims = claims.Where(c => !existingClaimIds.Contains(c.Id)).ToList();

        if (!newClaims.Any())
            return BadRequest("All provided claims are already associated with the role.");

        foreach (var claim in newClaims)
            role.Claims.Add(claim);

        await _unitOfWork.CommitAsync();
        return Success();
    }

    public async Task<IServiceResult> AddClaimToRoleAsync(long roleId, long claimId)
    {
        if (claimId <= 0)
            return BadRequest("Invalid claim ID.");

        var role = await _unitOfWork.GetRepository<Role, long>()
                                     .GetAsync(roleId, isTracking: true, includes: "Claims");
        if (role is null)
            return NotFound("Role not found.");

        var claim = await _unitOfWork.GetRepository<Claim, long>().GetAsync(claimId);
        if (claim is null)
            return NotFound("Claim not found.");

        if (role.Claims.Any(c => c.Id == claim.Id))
            return BadRequest($"Claim with ID {claim.Id} is already associated with the role.");

        role.Claims.Add(claim);
        await _unitOfWork.CommitAsync();

        return Success();
    }

    public async Task<IServiceResult> CreateAsync(CreateRoleDto createRoleDto)
    {
        var role = _autoMapper.Map<Role, CreateRoleDto>(createRoleDto, true);

        var existingRole = await _unitOfWork.GetRepository<Role, long>().FindAsync(r => r.Name == role.Name, false);
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
                                     .GetAllAsync(isTracking: false, includes: "Claims");

        var roleDtos = _autoMapper.Map<RoleDto, Role>(roles.ToList(), true);
        return Success(roleDtos);
    }

    public async Task<IServiceResult> GetAllByUserId(long userId)
    {
        var user = await _unitOfWork.GetRepository<User, long>()
                                     .GetAsync(userId, isTracking: false, includes: "Roles");

        if (user is null)
            return NotFound("User not found.");

        var roleDtos = _autoMapper.Map<RoleDto, Role>(user.Roles, true);

        return Success(roleDtos);
    }

    public async Task<IServiceResult> GetAsync(long roleId)
    {
        var role = await _unitOfWork.GetRepository<Role, long>()
                                     .GetAsync(roleId, isTracking: false, includes:"Claims");

        if (role is null)
            return NotFound("Role not found.");

        var roleDto = _autoMapper.Map<RoleDto, Role>(role, true);

        return Success(roleDto);
    }

    public async Task<IServiceResult> GetClaimsByRoleIdAsync(long roleId)
    {
        var role = await _unitOfWork.GetRepository<Role, long>()
                                     .GetAsync(roleId, isTracking: false, includes: "Claims");

        if (role is null)
            return NotFound("Role not found.");

        var claimDtos = _autoMapper.Map<UpdateClaimDto, Claim>(role.Claims);
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

        var roleDto = _autoMapper.Map<RoleDto, Role>(role, true);
        return Success(roleDto);
    }

    public async Task<IServiceResult> UpdateAsync(UpdateRoleDto updateRoleDto)
    {
        var existingRole = await _unitOfWork.GetRepository<Role, long>().GetAsync(updateRoleDto.Id);
        if (existingRole is null)
            return NotFound("Role not found.");

        existingRole.Name = updateRoleDto.Name;
        existingRole.Description = updateRoleDto.Description;

        await _unitOfWork.CommitAsync();

        var updatedRoleDto = _autoMapper.Map<UpdateRoleDto, Role>(existingRole, true);
        return Success(updatedRoleDto);
    }
}
