using N_Layer_App_EF_Template.Domain.Entities.Abstracts;
using N_Layer_App_EF_Template.Domain.Entities.Commons;

namespace N_Layer_App_EF_Template.Domain.Entities.Concretes;

public class User : BaseEntity<long>, ISoftDelete
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Email { get; set; }
    public bool EmailComfirmed { get; set; }
    public DateTime BirthDate { get; set; }
    public byte AccessFailedCount { get; set; }
    public bool LockOutEnabled { get; set; }
    public string PasswordHash { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool IsPermanently { get; set; }

    // Foregin Keys

    // Navigation Properties
    public virtual ICollection<UserLogin> UserLogins { get; set; }
    public virtual ICollection<Role> Roles { get; set; }
    public virtual ICollection<UserToken> UserTokens { get; set; }
}
