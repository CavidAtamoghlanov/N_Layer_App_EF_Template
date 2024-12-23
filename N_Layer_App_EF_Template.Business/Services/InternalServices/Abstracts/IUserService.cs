using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;

public interface IUserService
{
    Task<User> GetAsync(long id);
    Task<User> GetByEmailAsync(string email);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> CreateAsync(User user);
    Task<bool> DeleteAsync(long id);
    Task<User> UpdateAsync(User user);

    Task<IEnumerable<Role>> GetRolesAsync(long userId);
    Task<bool> AddRoleToUserAsync(long userId, string roleName);
    Task<bool> RemoveRoleFromUserAsync(long userId, string roleName);
    Task<IEnumerable<User>> GetUsersByRoleAsync(string roleName);
    Task<bool> UserHasRoleAsync(long userId, string roleName);
    Task<bool> AddRolesToUserAsync(long userId, IEnumerable<string> roleNames);
    Task<bool> RemoveRolesFromUserAsync(long userId, IEnumerable<string> roleNames);
}
