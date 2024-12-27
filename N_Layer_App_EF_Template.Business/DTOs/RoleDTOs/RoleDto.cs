using N_Layer_App_EF_Template.Business.DTOs.ClaimDTOs;

namespace N_Layer_App_EF_Template.Business.DTOs.RoleDTOs;

public class RoleDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<ClaimDto>? Claims { get; set; }
}