using N_Layer_App_EF_Template.Domain.Entities.Abstracts;
using N_Layer_App_EF_Template.Domain.Entities.Commons;

namespace N_Layer_App_EF_Template.Domain.Entities.Concretes;

public class UserLogin : BaseEntity<long>, ISoftDelete
{
    public string ProviderName { get; set; }
    public string ProviderKey { get; set; }
    public bool IsDeleted { get ; set ; }
    public DateTime? DeletedDate { get ; set ; }
    public bool IsPermanently { get ; set ; }

    // Foregin Keys
    public long UserId { get; set; }

    // Navigation Properties
    public virtual User User { get; set; }
}
