using N_Layer_App_EF_Template.Business.Responses;
using N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;
using N_Layer_App_EF_Template.Domain.Enums;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Concretes;

public class AuthService : IAuthService
{
    public Task<bool> ConfirmAsync(string token, string otp, ConfirmationMethod method)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ForgotPasswordAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<string> LoginAsync(string email, string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> LogOutAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<string> RegisterAsync(string firstName, string lastName, string? middleName, string email, string password, string? phoneNumber)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RepasswordAsync(long userId, string oldPassword, string newPassword)
    {
        throw new NotImplementedException();
    }
}
