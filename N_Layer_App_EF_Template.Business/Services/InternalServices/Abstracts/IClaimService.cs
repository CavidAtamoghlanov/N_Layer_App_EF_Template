using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;

public interface IClaimService
{
    Task<Claim> UpdateAsync(Claim role);
}
