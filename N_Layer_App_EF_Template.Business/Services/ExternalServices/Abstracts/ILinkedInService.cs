namespace N_Layer_App_EF_Template.Business.Services.ExternalServices.Abstracts;

public interface ILinkedInService
{
    Task<bool> SendOtpAsync(string username, string otp);
}
