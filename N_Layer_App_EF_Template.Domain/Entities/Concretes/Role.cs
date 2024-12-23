using N_Layer_App_EF_Template.Domain.Entities.Commons;

namespace N_Layer_App_EF_Template.Domain.Entities.Concretes;

public class Role : BaseEntity<long>
{
    public string Name { get; set; }
    public string Description { get; set; }

    // Foreigin Keys

    // Navigation Properties
    public virtual ICollection<User> Users { get; set; }
    public virtual ICollection<Claim> Claims { get; set; }
}
