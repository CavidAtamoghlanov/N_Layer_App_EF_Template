using Microsoft.EntityFrameworkCore;
using N_Layer_App_EF_Template.Configurations.EntityConfigurations;
using N_Layer_App_EF_Template.Domain.Entities.Abstracts;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    #region OnModelCreating && OnConfiguring

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoleClaimConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
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

    #region Tables

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<RoleClaim> RoleClaims { get; set; }
    public virtual DbSet<UserToken> UserTokens { get; set; }
    public virtual DbSet<UserLogin> UserLogins { get; set; }

    #endregion
}
