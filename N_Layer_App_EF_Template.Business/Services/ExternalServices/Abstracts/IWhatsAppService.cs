namespace N_Layer_App_EF_Template.Business.Services.ExternalServices.Abstracts;

public interface IWhatsAppService
{
    Task<bool> SendOtpAsync(string phoneNumber, string otp);
}
