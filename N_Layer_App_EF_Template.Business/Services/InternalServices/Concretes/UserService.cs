using N_Layer_App_EF_Template.Business.Mappings.Abstracts;
using N_Layer_App_EF_Template.Business.ServiceResults.Abstracts;
using N_Layer_App_EF_Template.Business.ServiceResults.Concretes;
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

    public Task<IServiceResult> AddRolesToUserAsync(long userId, IEnumerable<string> roleNames)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> AddRoleToUserAsync(long userId, string roleName)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> CreateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> GetRolesAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> GetUsersByRoleAsync(string roleName)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> RemoveRoleFromUserAsync(long userId, string roleName)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> RemoveRolesFromUserAsync(long userId, IEnumerable<string> roleNames)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> UserHasRoleAsync(long userId, string roleName)
    {
        throw new NotImplementedException();
    }
}
