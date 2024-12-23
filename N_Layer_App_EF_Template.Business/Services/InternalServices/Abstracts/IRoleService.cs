using N_Layer_App_EF_Template.Domain.Entities.Concretes;
using System.Security.Claims;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;

public interface IRoleService
{
    Task<Role> GetAsync(long roleId);
    Task<IEnumerable<Role>> GetAllAsync();
    Task<IEnumerable<Role>> GetAllByUserId(long userId);
    Task<Role> CreateAsync(Role role);
    Task<Role> UpdateAsync(Role role);
    Task<bool> DeleteAsync(long roleId);
    Task<IEnumerable<System.Security.Claims.Claim>> GetClaimsByRoleIdAsync(long roleId);
    Task AddClaimToRoleAsync(long roleId, System.Security.Claims.Claim claim);
    Task AddClaimsToRoleAsync(long roleId, IEnumerable<System.Security.Claims.Claim> claims);
    Task RemoveClaimFromRoleAsync(long roleId, System.Security.Claims.Claim claim);
    Task RemoveClaimsFromRoleAsync(long roleId, IEnumerable<System.Security.Claims.Claim> claims);
}
