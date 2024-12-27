using Microsoft.Extensions.DependencyInjection;
using N_Layer_App_EF_Template.Business.Mappings.Abstracts;
using N_Layer_App_EF_Template.Business.Services.ExternalServices.OtpServices.Abstracts;
using N_Layer_App_EF_Template.Business.Services.ExternalServices.OtpServices.Concretes;
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

        #region Otp Services
        services.AddScoped<IOtpService, FacebookOtpService>();
        services.AddScoped<IOtpService, InstagramOtpService>();
        services.AddScoped<IOtpService, TelegramOtpService>();
        services.AddScoped<IOtpService, WhatsAppOtpService>();
        services.AddScoped<IOtpService, SmsOtpService>();
        services.AddScoped<IOtpService, LinkedInOtpService>();
        services.AddScoped<IOtpService, EmailOtpService>();
        #endregion

        #region AutoMapper

        services.AddScoped<IAutoMapper, Business.Mappings.Concretes.AutoMapper>();

        #endregion
        return services;
    }
}
