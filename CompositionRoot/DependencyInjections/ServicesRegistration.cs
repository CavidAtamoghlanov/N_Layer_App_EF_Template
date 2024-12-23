using Microsoft.Extensions.DependencyInjection;
using N_Layer_App_EF_Template.Business.Mappings.Abstracts;
using N_Layer_App_EF_Template.Business.Mappings.Concretes;
using N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;
using N_Layer_App_EF_Template.Business.Services.InternalServices.Concretes;

namespace N_Layer_App_EF_Template.CompositionRoot.DependencyInjections;

public static class ServicesRegistration
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        #region Services

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IClaimService, ClaimService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();

        #endregion

        #region AutoMapper

        services.AddScoped<IAutoMapperConfiguration, AutoMapperConfiguration>();

        #endregion
        return services;
    }
}
