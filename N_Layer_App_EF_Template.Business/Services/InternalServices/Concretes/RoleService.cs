using N_Layer_App_EF_Template.Business.Responses;
using N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Concretes;

public class RoleService : ResponseMethods, IRoleService
{
    public Task AddClaimsToRoleAsync(long roleId, IEnumerable<System.Security.Claims.Claim> claims)
    {
        throw new NotImplementedException();
    }

    public Task AddClaimToRoleAsync(long roleId, System.Security.Claims.Claim claim)
    {
        throw new NotImplementedException();
    }

    public Task<Role> CreateAsync(Role role)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long roleId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Role>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Role>> GetAllByUserId(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<Role> GetAsync(long roleId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<System.Security.Claims.Claim>> GetClaimsByRoleIdAsync(long roleId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveClaimFromRoleAsync(long roleId, System.Security.Claims.Claim claim)
    {
        throw new NotImplementedException();
    }

    public Task RemoveClaimsFromRoleAsync(long roleId, IEnumerable<System.Security.Claims.Claim> claims)
    {
        throw new NotImplementedException();
    }

    public Task<Role> UpdateAsync(Role role)
    {
        throw new NotImplementedException();
    }
}
