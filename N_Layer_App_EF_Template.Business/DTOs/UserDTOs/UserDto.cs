using N_Layer_App_EF_Template.Business.DTOs.RoleDTOs;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Business.DTOs.UserDTOs;

public class UserDto
{
    public long Id { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public IEnumerable<RoleDto> Roles { get; set; }
}
