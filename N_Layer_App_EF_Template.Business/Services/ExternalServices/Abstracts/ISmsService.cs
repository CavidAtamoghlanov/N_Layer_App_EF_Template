namespace N_Layer_App_EF_Template.Business.Services.ExternalServices.Abstracts;

public interface ISmsService
{
    Task<bool> SendOtpAsync(string phoneNumber, string otp);
}
