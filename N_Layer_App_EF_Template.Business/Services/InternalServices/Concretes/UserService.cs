using N_Layer_App_EF_Template.Business.Responses;
using N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Concretes;

public class UserService : ResponseMethods, IUserService
{
    public Task<bool> AddRolesToUserAsync(long userId, IEnumerable<string> roleNames)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddRoleToUserAsync(long userId, string roleName)
    {
        throw new NotImplementedException();
    }

    public Task<User> CreateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Role>> GetRolesAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetUsersByRoleAsync(string roleName)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveRoleFromUserAsync(long userId, string roleName)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveRolesFromUserAsync(long userId, IEnumerable<string> roleNames)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UserHasRoleAsync(long userId, string roleName)
    {
        throw new NotImplementedException();
    }
}
