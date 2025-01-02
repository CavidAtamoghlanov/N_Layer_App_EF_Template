using N_Layer_App_EF_Template.Business.DTOs.ClaimDTOs;
using N_Layer_App_EF_Template.Business.Mappings.Abstracts;
using N_Layer_App_EF_Template.Business.ServiceResults.Abstracts;
using N_Layer_App_EF_Template.Business.Services.Commons;
using N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;
using N_Layer_App_EF_Template.DataAccess.UnitOfWorks.Abstracts;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Concretes;

public class ClaimService : BaseService, IClaimService
{
    public ClaimService(IUnitOfWork unitOfWork, IAutoMapper autoMapper) : base(unitOfWork, autoMapper)
    {
    }

    public async Task<IServiceResult> UpdateAsync(UpdateClaimDto claimDto)
    {
        var repo = _unitOfWork.GetRepository<Claim, long>();
        var existingClaim = await repo.GetAsync(claimDto.Id);
        if (existingClaim is null)
            return NotFound($"Claim with id {claimDto.Id} not found.");

        existingClaim.Name = claimDto.Name;
        existingClaim.Description = claimDto.Description;

        await _unitOfWork.GetRepository<Claim, long>().UpdateAsync(existingClaim);
        await _unitOfWork.CommitAsync();

        return Success(claimDto);
    }
}
