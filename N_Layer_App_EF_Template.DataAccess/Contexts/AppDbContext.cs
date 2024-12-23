using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using N_Layer_App_EF_Template.Domain.Entities.Abstracts;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;
using System.Linq.Expressions;
using System.Reflection;

namespace N_Layer_App_EF_Template.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    private static readonly MethodInfo ConfigureGlobalFiltersMethodInfo = typeof(AppDbContext)
        .GetMethod(nameof(ConfigureGlobalFilters), BindingFlags.Instance | BindingFlags.NonPublic)!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    #region OnModelCreating && OnConfiguring

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            ConfigureGlobalFiltersMethodInfo?
                .MakeGenericMethod(entityType.ClrType)
                .Invoke(this, new object[] { modelBuilder, entityType });
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

    #endregion

    #region SaveChange Override

    private void UpdateAuditFields()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is IBaseEntity<object> &&
                        (e.State == EntityState.Added || e.State == EntityState.Modified))
            .ToList();

        var currentUtcDate = DateTime.UtcNow;

        foreach (var entry in entries)
        {
            dynamic entity = entry.Entity;

            if (entry.State == EntityState.Added)
            {
                entity.CreatedDate = currentUtcDate;
            }

            entity.UpdatedDate = currentUtcDate;

            if (entry.Entity is ISoftDelete softDeleteEntity)
            {
                if (entry.State == EntityState.Modified && softDeleteEntity.IsDeleted)
                {
                    softDeleteEntity.DeletedDate = currentUtcDate;
                }
            }
        }
    }

    public override int SaveChanges()
    {
        UpdateAuditFields();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditFields();
        return await base.SaveChangesAsync(cancellationToken);
    }

    #endregion

    #region Global_Filtring
    protected void ConfigureGlobalFilters<TEntity>(ModelBuilder modelBuilder, IMutableEntityType entityType) where TEntity : class
    {
        if (ShouldFilterEntity<TEntity>(entityType))
        {
            var filterExpression = CreateFilterExpression<TEntity>();
            if (filterExpression is not null)
            {
                modelBuilder.Entity<TEntity>().HasQueryFilter(filterExpression);
            }
        }
    }

    protected virtual bool ShouldFilterEntity<TEntity>(IMutableEntityType entityType) where TEntity : class
    {
        if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
        {
            return true;
        }

        return false;
    }

    protected virtual Expression<Func<TEntity, bool>>? CreateFilterExpression<TEntity>() where TEntity : class
    {
        Expression<Func<TEntity, bool>>? expression = null;

        if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
        {
            Expression<Func<TEntity, bool>> softDeleteFilter = e => !((ISoftDelete)e).IsDeleted;
            expression = softDeleteFilter;
        }

        return expression;
    }
    #endregion

    #region Tables

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<Claim> Claims { get; set; }
    public virtual DbSet<UserToken> UserTokens { get; set; }
    public virtual DbSet<UserLogin> UserLogins { get; set; }

    #endregion
}
