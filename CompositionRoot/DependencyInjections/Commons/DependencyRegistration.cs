using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace N_Layer_App_EF_Template.CompositionRoot.DependencyInjections.Commons;

public static class DependencyRegistration
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddDbDependencies(configuration);
        services.AddJwtDependencies(configuration);
        services.AddServiceDependencies();
        services.AddRepositoryDependencies();

        return services;
    }
}
