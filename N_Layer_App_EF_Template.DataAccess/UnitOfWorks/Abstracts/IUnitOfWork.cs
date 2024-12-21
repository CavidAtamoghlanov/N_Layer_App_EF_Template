using N_Layer_App_EF_Template.DataAccess.Repositories.Abstracts;
using N_Layer_App_EF_Template.Domain.Entities.Abstracts;

namespace N_Layer_App_EF_Template.DataAccess.UnitOfWorks.Abstracts;

public interface IUnitOfWork
{
    IRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : class, IBaseEntity<TKey>, new();

    Task CommitAsync();
}
