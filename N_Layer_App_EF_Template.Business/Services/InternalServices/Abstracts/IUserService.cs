using N_Layer_App_EF_Template.Business.DTOs.UserDTOs;
using N_Layer_App_EF_Template.Business.ServiceResults.Abstracts;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;

public interface IUserService
{
    Task<IServiceResult> GetAsync(long id);
    Task<IServiceResult> GetByEmailAsync(string email);
    Task<IServiceResult> GetAllAsync();
    Task<IServiceResult> CreateAsync(UserCreateDTO userCreateDTO);
    Task<IServiceResult> DeleteAsync(long id);
    Task<IServiceResult> UpdateAsync(UpdateUserDTO updateUserDTO);

    Task<IServiceResult> GetRolesAsync(long userId);
    Task<IServiceResult> AddRoleToUserAsync(long userId, long roleId);
    Task<IServiceResult> RemoveRoleFromUserAsync(long userId, long roleId);
    Task<IServiceResult> GetUsersByRoleAsync(string roleName);
    Task<IServiceResult> UserHasRoleAsync(long userId, long roleId);
    Task<IServiceResult> AddRolesToUserAsync(long userId, IEnumerable<long> roleIds);
    Task<IServiceResult> RemoveRolesFromUserAsync(long userId, IEnumerable<long> roleIds);
}
