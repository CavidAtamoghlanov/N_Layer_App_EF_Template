using N_Layer_App_EF_Template.Domain.Entities.Abstracts;
using System.Linq.Expressions;

namespace N_Layer_App_EF_Template.DataAccess.Repositories.Abstracts;

public interface IRepository<TEntity, TKey> where TEntity : IBaseEntity<TKey>, new()
{
    // Queries
    IQueryable<TEntity> GetAll(bool isTracking = true);
    Task<IList<TEntity>> GetAllAsync(bool isTracking = true);
    IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, bool isTracking = true);
    Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, bool isTracking = true);
    Task<TEntity?> GetAsync(TKey id, bool isTracking = true, params string[] includeProperties);
    Task<IList<TEntity>> GetAllIncludingAsync(Expression<Func<TEntity, bool>> predicate, bool isTracking = true, params string[] includeProperties);
    Task<IQueryable<TEntity>> GetAllIncludingQueryAsync(Expression<Func<TEntity, bool>> predicate, bool isTracking = true, params string[] includeProperties);

    // Commands
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    Task UpdateAsync(TEntity entity);
    Task UpdateRangeAsync(IEnumerable<TEntity> entities);
    Task DeleteAsync(TEntity entity);
    Task DeleteAsync(TKey id);
    Task<int> SaveChangesAsync();
}
