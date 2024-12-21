using N_Layer_App_EF_Template.Domain.Entities.Commons;

namespace N_Layer_App_EF_Template.Domain.Entities.Concretes;

public class RoleClaim : BaseEntity<long>
{
    public string Name { get; set; }
    public string Description { get; set; }

    // Foreigin Keys

    // Navigation Properties
    public virtual ICollection<Role> Roles { get; set; }
}
