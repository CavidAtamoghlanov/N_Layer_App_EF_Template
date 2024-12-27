using N_Layer_App_EF_Template.Domain.Enums;

namespace N_Layer_App_EF_Template.Business.Services.ExternalServices.OtpServices.Abstracts;

public interface IOtpService
{
    ConfirmationMethod Method { get; }
    Task<bool> SendOtpAsync(string identifier, string otp);
}