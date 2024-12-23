namespace N_Layer_App_EF_Template.Business.Services.ExternalServices.Abstracts;

public interface IEmailService
{
    Task<bool> SendOtpAsync(string email, string otp);
}
