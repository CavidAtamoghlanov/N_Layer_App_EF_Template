using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using N_Layer_App_EF_Template.DataAccess.Contexts;

namespace N_Layer_App_EF_Template.CompositionRoot.DependencyInjections;

public static class DbRegistration
{
    public static IServiceCollection AddDbDependencies(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }

}
