using N_Layer_App_EF_Template.Domain.Entities.Abstracts;

namespace N_Layer_App_EF_Template.Domain.Entities.Commons;

public abstract class BaseEntity<TKey> : IBaseEntity<TKey>
{
    public TKey Id { get; set; } 
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
