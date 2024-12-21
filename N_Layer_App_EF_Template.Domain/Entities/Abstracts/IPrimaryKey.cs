namespace N_Layer_App_EF_Template.Domain.Entities.Abstracts;

public interface IPrimaryKey<TKey>
{
    public TKey Id { get; set; }
}
