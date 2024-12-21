namespace N_Layer_App_EF_Template.Domain.Entities.Abstracts;

public interface ISoftDelete
{
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool IsPermanently { get; set; }
}
