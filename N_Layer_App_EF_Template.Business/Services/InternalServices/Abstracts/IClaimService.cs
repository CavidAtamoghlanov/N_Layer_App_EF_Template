using N_Layer_App_EF_Template.Business.DTOs.ClaimDTOs;
using N_Layer_App_EF_Template.Business.ServiceResults.Abstracts;
using N_Layer_App_EF_Template.Business.ServiceResults.Concretes;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;

public interface IClaimService
{
    Task<IServiceResult> UpdateAsync(ClaimDto claimDto);
}
