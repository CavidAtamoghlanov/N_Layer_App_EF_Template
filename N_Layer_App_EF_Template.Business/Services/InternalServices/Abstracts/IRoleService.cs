using N_Layer_App_EF_Template.Business.DTOs.ClaimDTOs;
using N_Layer_App_EF_Template.Business.DTOs.RoleDTOs;
using N_Layer_App_EF_Template.Business.ServiceResults.Abstracts;
using N_Layer_App_EF_Template.Business.ServiceResults.Concretes;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;

public interface IRoleService
{
    Task<IServiceResult> GetAsync(long roleId);
    Task<IServiceResult> GetAllAsync();
    Task<IServiceResult> GetAllByUserId(long userId);
    Task<IServiceResult> CreateAsync(CreateRoleDto createRoleDto);
    Task<IServiceResult> UpdateAsync(UpdateRoleDto updateRoleDto);
    Task<IServiceResult> DeleteAsync(long roleId);
    Task<IServiceResult> GetClaimsByRoleIdAsync(long roleId);
    Task<IServiceResult> AddClaimToRoleAsync(long roleId, long claimId);
    Task<IServiceResult> AddClaimsToRoleAsync(long roleId, IEnumerable<long> claimIds);
    Task<IServiceResult> RemoveClaimFromRoleAsync(long roleId, long claimId);
    Task<IServiceResult> RemoveClaimsFromRoleAsync(long roleId, IEnumerable<long> claimIds);
}
