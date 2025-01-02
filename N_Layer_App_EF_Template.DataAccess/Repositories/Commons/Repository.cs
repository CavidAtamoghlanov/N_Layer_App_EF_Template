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

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, bool isTracking = true, params string[] includes)
    {
        var query = ApplyIncludes(_dbSet, includes, isTracking);
        return await query.Where(predicate).ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(bool isTracking = true, params string[] includes)
    {
        var query = ApplyIncludes(_dbSet, includes, isTracking);
        return await query.ToListAsync();
    }

    public async Task<TEntity?> GetAsync(TKey id, bool isTracking = true, params string[] includes)
    {
        var query = ApplyIncludes(_dbSet, includes, isTracking);
        return await query.FirstOrDefaultAsync(e => e.Id!.Equals(id));
    }

    private IQueryable<TEntity> ApplyIncludes(IQueryable<TEntity> query, string[] includes, bool isTracking)
    {
        if (!isTracking)
            query = query.AsNoTracking();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return query;
    }

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
