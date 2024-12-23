using N_Layer_App_EF_Template.Business.Mappings.Abstracts;
using N_Layer_App_EF_Template.Business.Services.Commons;
using N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;
using N_Layer_App_EF_Template.DataAccess.UnitOfWorks.Abstracts;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Concretes;

public class RoleService : BaseService, IRoleService
{
    public RoleService(IUnitOfWork unitOfWork, IAutoMapperConfiguration autoMapper) : base(unitOfWork, autoMapper)
    { }

    public Task AddClaimsToRoleAsync(long roleId, IEnumerable<Claim> claims)
    {
        throw new NotImplementedException();
    }

    public Task AddClaimToRoleAsync(long roleId, Claim claim)
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

    public Task<IEnumerable<Claim>> GetClaimsByRoleIdAsync(long roleId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveClaimFromRoleAsync(long roleId, string claimId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveClaimsFromRoleAsync(long roleId, IEnumerable<string> claimIds)
    {
        throw new NotImplementedException();
    }

    public Task<Role> UpdateAsync(Role role)
    {
        throw new NotImplementedException();
    }
}
