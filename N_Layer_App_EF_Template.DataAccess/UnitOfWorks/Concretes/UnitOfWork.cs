using N_Layer_App_EF_Template.DataAccess.Contexts;
using N_Layer_App_EF_Template.DataAccess.Repositories.Abstracts;
using N_Layer_App_EF_Template.DataAccess.Repositories.Commons;
using N_Layer_App_EF_Template.DataAccess.UnitOfWorks.Abstracts;

namespace N_Layer_App_EF_Template.DataAccess.UnitOfWorks.Concretes;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly AppDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly Dictionary<Type, object> _repositories = [];

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    IRepository<TEntity, TKey> IUnitOfWork.GetRepository<TEntity, TKey>()
    {
        if (_repositories.ContainsKey(typeof(TEntity)))
            return (IRepository<TEntity, TKey>)_repositories[typeof(TEntity)];

        var repository = new Repository<TEntity, TKey>(_context);
        _repositories.Add(typeof(TEntity), repository);
        return repository;
    }
}
