using N_Layer_App_EF_Template.Business.DTOs.UserDTOs;
using N_Layer_App_EF_Template.Business.Helpers;
using N_Layer_App_EF_Template.Business.Mappings.Abstracts;
using N_Layer_App_EF_Template.Business.ServiceResults.Abstracts;
using N_Layer_App_EF_Template.Business.Services.Commons;
using N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;
using N_Layer_App_EF_Template.DataAccess.UnitOfWorks.Abstracts;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Concretes;

public class UserService : BaseService, IUserService
{
    public UserService(IUnitOfWork unitOfWork, IAutoMapper autoMapper) : base(unitOfWork, autoMapper)
    {
    }

    public async Task<IServiceResult> AddRolesToUserAsync(long userId, IEnumerable<long> roleIds)
    {
        var userRepository = _unitOfWork.GetRepository<User, long>();
        var roleRepository = _unitOfWork.GetRepository<Role, long>();

        var user = await userRepository.GetAsync(userId, includes: ["Roles"]);
        if (user is null)
            return NotFound("User not found");

        var roles = await roleRepository.FindAsync(r => roleIds.Contains(r.Id));
        if (!roles.Any())
            return NotFound("No roles found");

        foreach (var role in roles)
            if (!user.Roles.Contains(role))
                user.Roles.Add(role);

        await userRepository.UpdateAsync(user);
        await _unitOfWork.CommitAsync();

        return Success();
    }

    public async Task<IServiceResult> AddRoleToUserAsync(long userId, long roleId)
    {
        var userRepository = _unitOfWork.GetRepository<User, long>();
        var roleRepository = _unitOfWork.GetRepository<Role, long>();

        var user = await userRepository.GetAsync(userId, includes: ["Roles"]);
        if (user is null)
            return NotFound("User not found");

        var role = await roleRepository.GetAsync(roleId);
        if (role is null)
            return NotFound("Role not found");

        if (user.Roles.Contains(role))
            return BadRequest("User already has this role.");

        user.Roles.Add(role);

        await userRepository.UpdateAsync(user);
        await _unitOfWork.CommitAsync();

        return Success();
    }

    public async Task<IServiceResult> CreateAsync(UserCreateDTO userCreateDTO)
    {
        var userRepository = _unitOfWork.GetRepository<User, long>();
        var roleRepository = _unitOfWork.GetRepository<Role, long>();

        var existingUser = await userRepository.FindAsync(u => u.Email == userCreateDTO.Email);
        if (existingUser.Any())
            return BadRequest("A user with this email already exists.");

        var user = new User
        {
            FirstName = userCreateDTO.FirstName,
            LastName = userCreateDTO.LastName,
            MiddleName = userCreateDTO.MiddleName,
            Email = userCreateDTO.Email,
            BirthDate = userCreateDTO.BirthDate,
            PasswordHash = PasswordHelper.HashPassword(userCreateDTO.Password),
            PhoneNumber = userCreateDTO.PhoneNumber,
            EmailComfirmed = false,
            LockOutEnabled = false,
            AccessFailedCount = 0,
            IsDeleted = false,
            IsPermanently = false
        };

        await userRepository.AddAsync(user);
        await _unitOfWork.CommitAsync();

        return Success();
    }

    public async Task<IServiceResult> DeleteAsync(long id)
    {
        var userRepository = _unitOfWork.GetRepository<User, long>();
        var user = await userRepository.GetAsync(id);
        if (user is null)
            return BadRequest("User not found");

        await userRepository.DeleteAsync(user);
        await _unitOfWork.CommitAsync();
        return Success();
    }

    public async Task<IServiceResult> GetAllAsync()
    {
        var users = await _unitOfWork.GetRepository<User, long>().GetAllAsync(includes: ["Roles", "UserLogins", "UserTokens"]);
        var userDtos = _autoMapper.Map<UserDto, User>(users, true);
        return Success(userDtos);
    }

    public async Task<IServiceResult> GetAsync(long id)
    {
        var user = await _unitOfWork.GetRepository<User, long>().GetAsync(id, includes: ["Roles", "UserLogins", "UserTokens"]);
        if (user is null)
            return BadRequest("User not found");

        var userDto = _autoMapper.Map<UserDto, User>(user, true);
        return Success(userDto);
    }

    public async Task<IServiceResult> GetByEmailAsync(string email)
    {
        var userRepository = _unitOfWork.GetRepository<User, long>();

        var user = await userRepository.FindAsync(u => u.Email == email, includes: ["Roles", "UserLogins", "UserTokens"]);
        if (user is null)
            return NotFound("User not found");

        var userDtos = _autoMapper.Map<UserDto, User>(user, true);
        return Success(userDtos);
    }

    public async Task<IServiceResult> GetRolesAsync(long userId)
    {
        var user = await _unitOfWork.GetRepository<User, long>().GetAsync(userId, includes: ["Roles"]);
        if (user is null)
            return BadRequest("User not found");

        var roles = user.Roles.Select(r => r.Name).ToList();
        return Success(roles);
    }

    public async Task<IServiceResult> GetUsersByRoleAsync(string roleName)
    {
        var userRepository = _unitOfWork.GetRepository<User, long>();
        var roleRepository = _unitOfWork.GetRepository<Role, long>();

        var role = await roleRepository.FindAsync(r => r.Name == roleName);
        if (!role.Any())
            return NotFound("Role not found");

        var users = await userRepository.FindAsync(u => u.Roles.Any(r => r.Name == roleName));
        if (!users.Any())
            return NotFound("No users found with this role");

        return Success(users);
    }

    public async Task<IServiceResult> RemoveRoleFromUserAsync(long userId, long roleId)
    {
        var userRepository = _unitOfWork.GetRepository<User, long>();
        var roleRepository = _unitOfWork.GetRepository<Role, long>();

        var user = await userRepository.GetAsync(userId, includes: ["Roles"]);
        if (user is null)
            return NotFound("User not found");

        var role = user.Roles.FirstOrDefault(r => r.Id == roleId);
        if (role is null)
            return NotFound("Role not found");

        user.Roles.Remove(role);

        await userRepository.UpdateAsync(user);
        await _unitOfWork.CommitAsync();

        return Success();
    }

    public async Task<IServiceResult> RemoveRolesFromUserAsync(long userId, IEnumerable<long> roleIds)
    {
        var userRepository = _unitOfWork.GetRepository<User, long>();
        var roleRepository = _unitOfWork.GetRepository<Role, long>();

        var user = await userRepository.GetAsync(userId, includes: ["Roles"]);
        if (user is null)
            return NotFound("User not found");

        var roles = await roleRepository.FindAsync(r => roleIds.Contains(r.Id));
        if (!roles.Any())
            return NotFound("No roles found");

        foreach (var role in roles)
            if (user.Roles.Contains(role))
                user.Roles.Remove(role);

        await userRepository.UpdateAsync(user);
        await _unitOfWork.CommitAsync();

        return Success();
    }

    public async Task<IServiceResult> UpdateAsync(UpdateUserDTO updateUserDTO)
    {
        var userRepository = _unitOfWork.GetRepository<User, long>();

        var user = await userRepository.GetAsync(updateUserDTO.Id);
        if (user == null)
            return NotFound("User not found");

        user.FirstName = updateUserDTO.FirstName;
        user.LastName = updateUserDTO.LastName;
        user.MiddleName = updateUserDTO.MiddleName;
        user.Email = updateUserDTO.Email;
        user.PhoneNumber = updateUserDTO.PhoneNumber;
        user.BirthDate = updateUserDTO.BirthDate;

        await userRepository.UpdateAsync(user);
        await _unitOfWork.CommitAsync();

        return Success();
    }

    public async Task<IServiceResult> UserHasRoleAsync(long userId, long roleId)
    {
        var userRepository = _unitOfWork.GetRepository<User, long>();
        var roleRepository = _unitOfWork.GetRepository<Role, long>();

        var user = await userRepository.GetAsync(userId, includes: ["Roles"]);
        if (user is null)
            return NotFound("User not found");

        var role = user.Roles.FirstOrDefault(r => r.Id == roleId);
        if (role is null)
            return NotFound("Role not found");

        if (!user.Roles.Contains(role))
            return NotFound("User does not have the role.");
        return Success();
    }
}
