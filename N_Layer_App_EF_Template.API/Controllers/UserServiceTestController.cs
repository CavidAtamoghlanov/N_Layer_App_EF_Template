using Microsoft.AspNetCore.Mvc;
using N_Layer_App_EF_Template.Business.DTOs.UserDTOs;
using N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;

namespace N_Layer_App_EF_Template.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserServiceTestController : ControllerBase
{
    private readonly IUserService _userService;

    public UserServiceTestController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet("Get/{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var result = await _userService.GetAsync(id);
        return Ok(result);
    }

    [HttpGet("GetByEmail/{email}")]
    public async Task<IActionResult> GetByEmail(string email)
    {
        var result = await _userService.GetByEmailAsync(email);
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _userService.GetAllAsync();
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] UserCreateDTO userCreateDTO)
    {
        var result = await _userService.CreateAsync(userCreateDTO);
        return Ok(result);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _userService.DeleteAsync(id);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateUserDTO updateUserDTO)
    {
        var result = await _userService.UpdateAsync(updateUserDTO);
        return Ok(result);
    }

    [HttpGet("GetRoles/{userId}")]
    public async Task<IActionResult> GetRoles(long userId)
    {
        var result = await _userService.GetRolesAsync(userId);
        return Ok(result);
    }

    [HttpPost("AddRoleToUser")]
    public async Task<IActionResult> AddRoleToUser(long userId, long roleId)
    {
        var result = await _userService.AddRoleToUserAsync(userId, roleId);
        return Ok(result);
    }

    [HttpDelete("RemoveRoleFromUser")]
    public async Task<IActionResult> RemoveRoleFromUser(long userId, long roleId)
    {
        var result = await _userService.RemoveRoleFromUserAsync(userId, roleId);
        return Ok(result);
    }

    [HttpPost("AddRolesToUser")]
    public async Task<IActionResult> AddRolesToUser(long userId, [FromBody] IEnumerable<long> roleIds)
    {
        var result = await _userService.AddRolesToUserAsync(userId, roleIds);
        return Ok(result);
    }

    [HttpDelete("RemoveRolesFromUser")]
    public async Task<IActionResult> RemoveRolesFromUser(long userId, [FromBody] IEnumerable<long> roleIds)
    {
        var result = await _userService.RemoveRolesFromUserAsync(userId, roleIds);
        return Ok(result);
    }

    [HttpGet("GetUsersByRole/{roleName}")]
    public async Task<IActionResult> GetUsersByRole(string roleName)
    {
        var result = await _userService.GetUsersByRoleAsync(roleName);
        return Ok(result);
    }

    [HttpGet("UserHasRole")]
    public async Task<IActionResult> UserHasRole(long userId, long roleId)
    {
        var result = await _userService.UserHasRoleAsync(userId, roleId);
        return Ok(result);
    }
}
