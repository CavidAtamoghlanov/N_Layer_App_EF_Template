using N_Layer_App_EF_Template.Domain.Entities.Commons;

namespace N_Layer_App_EF_Template.Domain.Entities.Concretes;

public class UserToken:BaseEntity<string>
{
    public string Value { get; set; }
    public string Key{ get; set; }
    public DateTime ExpireDate { get; set; }

    // Foregin Keys
    public long? UserId { get; set; }

    // Navigation Properties
    public virtual User? User { get; set; }
}
