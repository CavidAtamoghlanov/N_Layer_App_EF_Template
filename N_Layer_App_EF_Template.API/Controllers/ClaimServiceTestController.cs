using Microsoft.AspNetCore.Mvc;
using N_Layer_App_EF_Template.Business.DTOs.ClaimDTOs;
using N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;

namespace N_Layer_App_EF_Template.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClaimServiceTestController : ControllerBase
{
    private readonly IClaimService _claimService;

    public ClaimServiceTestController(IClaimService claimService)
    {
        _claimService = claimService;
    }

    // Test endpoint for updating a claim
    [HttpPut("UpdateClaim")]
    public async Task<IActionResult> TestUpdateClaim([FromBody] UpdateClaimDto claimDto)
    {
        var result = await _claimService.UpdateAsync(claimDto);

        return StatusCode((int)result.StatusCode, result);
    }
}
