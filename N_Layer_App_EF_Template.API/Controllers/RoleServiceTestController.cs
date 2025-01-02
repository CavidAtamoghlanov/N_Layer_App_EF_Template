using Microsoft.AspNetCore.Mvc;
using N_Layer_App_EF_Template.Business.DTOs.ClaimDTOs;
using N_Layer_App_EF_Template.Business.DTOs.RoleDTOs;
using N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;


namespace N_Layer_App_EF_Template.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleServiceTestController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleServiceTestController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpPost("AddClaimsToRole")]
    public async Task<IActionResult> TestAddClaimsToRole([FromBody] RoleClaimDto1 roleClaimDto)
    {
        var result = await _roleService.AddClaimsToRoleAsync(roleClaimDto.RoleId, roleClaimDto.ClaimIds);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpPost("AddClaimToRole")]
    public async Task<IActionResult> TestAddClaimToRole([FromBody] RoleClaimDto2 roleClaimDto)
    {
        var result = await _roleService.AddClaimToRoleAsync(roleClaimDto.RoleId, roleClaimDto.ClaimId);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpPost("CreateRole")]
    public async Task<IActionResult> TestCreateRole([FromBody] CreateRoleDto roleDto)
    {
        var result = await _roleService.CreateAsync(roleDto);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpDelete("DeleteRole/{roleId}")]
    public async Task<IActionResult> TestDeleteRole(long roleId)
    {
        var result = await _roleService.DeleteAsync(roleId);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpGet("GetAllRoles")]
    public async Task<IActionResult> TestGetAllRoles()
    {
        var result = await _roleService.GetAllAsync();
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpGet("GetRoleById/{roleId}")]
    public async Task<IActionResult> TestGetRoleById(long roleId)
    {
        var result = await _roleService.GetAsync(roleId);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpGet("GetClaimsByRoleId/{roleId}")]
    public async Task<IActionResult> TestGetClaimsByRoleId(long roleId)
    {
        var result = await _roleService.GetClaimsByRoleIdAsync(roleId);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpDelete("RemoveClaimFromRole/{roleId}/{claimId}")]
    public async Task<IActionResult> TestRemoveClaimFromRole(long roleId, long claimId)
    {
        var result = await _roleService.RemoveClaimFromRoleAsync(roleId, claimId);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpDelete("RemoveClaimsFromRole/{roleId}")]
    public async Task<IActionResult> TestRemoveClaimsFromRole(long roleId, [FromBody] List<long> claimIds)
    {
        var result = await _roleService.RemoveClaimsFromRoleAsync(roleId, claimIds);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpPut("UpdateRole")]
    public async Task<IActionResult> TestUpdateRole([FromBody] UpdateRoleDto roleDto)
    {
        var result = await _roleService.UpdateAsync(roleDto);
        return StatusCode((int)result.StatusCode, result);
    }
}

public class RoleClaimDto
{
    public long RoleId { get; set; }
    public IEnumerable<UpdateClaimDto> Claims { get; set; }
    public UpdateClaimDto Claim { get; set; }
}
public class RoleClaimDto2
{
    public long RoleId { get; set; }
    public long ClaimId { get; set; }
}

public class RoleClaimDto1
{
    public long RoleId { get; set; }
    public IEnumerable<long> ClaimIds { get; set; }
}