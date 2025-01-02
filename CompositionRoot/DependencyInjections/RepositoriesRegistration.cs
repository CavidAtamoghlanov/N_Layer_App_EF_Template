using Microsoft.Extensions.DependencyInjection;
using N_Layer_App_EF_Template.DataAccess.Repositories.Abstracts;
using N_Layer_App_EF_Template.DataAccess.Repositories.Commons;
using N_Layer_App_EF_Template.DataAccess.Repositories.Concretes;
using N_Layer_App_EF_Template.DataAccess.UnitOfWorks.Abstracts;
using N_Layer_App_EF_Template.DataAccess.UnitOfWorks.Concretes;

namespace N_Layer_App_EF_Template.CompositionRoot.DependencyInjections;

public static class RepositoriesRegistration
{
    public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services)
    {
        #region Repositories
        // Add generic repositories here
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

        // Add specific repositories here
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserLoginRepository, UserLoginRepository>();
        services.AddScoped<IUserTokenRepository, UserTokenRepository>();
        services.AddScoped<IClaimRepository, ClaimRepository>();
        #endregion

        #region UnitOfWork
        // Add UnitOfWork here
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        #endregion
        return services;
    }
}
