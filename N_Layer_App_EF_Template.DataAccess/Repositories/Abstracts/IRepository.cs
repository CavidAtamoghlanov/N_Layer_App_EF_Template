using N_Layer_App_EF_Template.Domain.Entities.Abstracts;
using System.Linq.Expressions;

namespace N_Layer_App_EF_Template.DataAccess.Repositories.Abstracts;

public interface IRepository<TEntity, TKey> where TEntity : IBaseEntity<TKey>, new()
{
    // Queries
    Task<TEntity?> GetAsync(TKey id, bool isTracking = true, params string[] includes);
    Task<IEnumerable<TEntity>> GetAllAsync(bool isTracking = true, params string[] includes);
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, bool isTracking = true, params string[] includes);

    // Commands
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    Task UpdateAsync(TEntity entity);
    Task UpdateRangeAsync(IEnumerable<TEntity> entities);
    Task DeleteAsync(TEntity entity);
    Task DeleteAsync(TKey id);
    Task<int> SaveChangesAsync();
}
