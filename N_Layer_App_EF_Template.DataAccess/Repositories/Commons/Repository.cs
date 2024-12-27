using Microsoft.EntityFrameworkCore;
using N_Layer_App_EF_Template.DataAccess.Contexts;
using N_Layer_App_EF_Template.DataAccess.Repositories.Abstracts;
using N_Layer_App_EF_Template.Domain.Entities.Abstracts;
using System.Linq.Expressions;

namespace N_Layer_App_EF_Template.DataAccess.Repositories.Commons;

public class Repository<TEntity, TKey>(AppDbContext context) : IRepository<TEntity, TKey> where TEntity : class, IBaseEntity<TKey>, new()
{
    protected readonly AppDbContext _context = context;
    protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        if (entity is not null)
        {
            _dbSet.Remove(entity);
            await SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(TKey id)
    {
        var entity = await GetAsync(id);
        if (entity is not null)
        {
            _dbSet.Remove(entity);
            await SaveChangesAsync();
        }
    }

    public IQueryable<TEntity> GetAll(bool isTracking = true)
    {
        return isTracking ? _dbSet : _dbSet.AsNoTracking();
    }

    public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, bool isTracking)
    {
        return isTracking ? _dbSet.Where(predicate) : _dbSet.Where(predicate).AsNoTracking();
    }

    public async Task<IList<TEntity>> GetAllAsync(bool isTracking = true)
    {
        return await (isTracking ? _dbSet : _dbSet.AsNoTracking()).ToListAsync();
    }

    public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, bool isTracking = true)
    {
        return await (isTracking ? _dbSet.Where(predicate) : _dbSet.Where(predicate).AsNoTracking()).ToListAsync();
    }

    public async Task<TEntity?> GetAsync(TKey id, bool isTracking = true, params string[] includeProperties)
    {
        var query = isTracking ? _dbSet : _dbSet.AsNoTracking();

        foreach (var includeProperty in includeProperties)
            query = query.Include(includeProperty);

        return await query.FirstOrDefaultAsync(e => e.Id!.Equals(id));
    }

    public async Task<IList<TEntity>> GetAllIncludingAsync(Expression<Func<TEntity, bool>> predicate, bool isTracking = true, params string[] includeProperties)
    {
        var query = isTracking ? _dbSet : _dbSet.AsNoTracking();

        foreach (var includeProperty in includeProperties)
            query = query.Include(includeProperty);

        return await query.Where(predicate).ToListAsync();
    }

    public async Task<IQueryable<TEntity>> GetAllIncludingQueryAsync(Expression<Func<TEntity, bool>> predicate, bool isTracking = true, params string[] includeProperties)
    {
        var query = isTracking ? _dbSet : _dbSet.AsNoTracking();

        foreach (var includeProperty in includeProperties)
            query = query.Include(includeProperty);

        return await Task.FromResult(query.Where(predicate));
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
    {
        _dbSet.UpdateRange(entities);
        await SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
