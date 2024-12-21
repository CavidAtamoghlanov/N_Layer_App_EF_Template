namespace N_Layer_App_EF_Template.Domain.Entities.Abstracts;

public interface IBaseEntity<TKey> : IPrimaryKey<TKey>
{
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
