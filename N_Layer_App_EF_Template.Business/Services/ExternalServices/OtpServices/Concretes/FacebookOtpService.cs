using N_Layer_App_EF_Template.Business.Services.ExternalServices.OtpServices.Abstracts;
using N_Layer_App_EF_Template.Domain.Enums;

namespace N_Layer_App_EF_Template.Business.Services.ExternalServices.OtpServices.Concretes;

public class FacebookOtpService : IOtpService
{
    public ConfirmationMethod Method => ConfirmationMethod.Facebook;

    public Task<bool> SendOtpAsync(string identifier, string otp)
    {
        throw new NotImplementedException();
    }
}
