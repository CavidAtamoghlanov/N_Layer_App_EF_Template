using N_Layer_App_EF_Template.Business.ServiceResults.Abstracts;
using N_Layer_App_EF_Template.Business.ServiceResults.Concretes;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;

public interface IUserService
{
    Task<IServiceResult> GetAsync(long id);
    Task<IServiceResult> GetByEmailAsync(string email);
    Task<IServiceResult> GetAllAsync();
    Task<IServiceResult> CreateAsync(User user);
    Task<IServiceResult> DeleteAsync(long id);
    Task<IServiceResult> UpdateAsync(User user);

    Task<IServiceResult> GetRolesAsync(long userId);
    Task<IServiceResult> AddRoleToUserAsync(long userId, string roleName);
    Task<IServiceResult> RemoveRoleFromUserAsync(long userId, string roleName);
    Task<IServiceResult> GetUsersByRoleAsync(string roleName);
    Task<IServiceResult> UserHasRoleAsync(long userId, string roleName);
    Task<IServiceResult> AddRolesToUserAsync(long userId, IEnumerable<string> roleNames);
    Task<IServiceResult> RemoveRolesFromUserAsync(long userId, IEnumerable<string> roleNames);
}
