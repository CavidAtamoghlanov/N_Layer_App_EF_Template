using N_Layer_App_EF_Template.Business.Responses;
using N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Concretes;

public class ClaimService : ResponseMethods, IClaimService
{
    public Task<Claim> UpdateAsync(Claim role)
    {
        throw new NotImplementedException();
    }
}
