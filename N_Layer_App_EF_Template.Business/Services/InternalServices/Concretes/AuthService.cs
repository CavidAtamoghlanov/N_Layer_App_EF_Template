using N_Layer_App_EF_Template.Business.Responses;
using N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;
using N_Layer_App_EF_Template.Domain.Enums;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Concretes;

public class AuthService : ResponseMethods, IAuthService
{
    public Task<bool> ConfirmAsync(string contact, ConfirmationMethod method)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ForgotePasswordAsync(string email)
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

    public Task<string> RegisterAsync(string email, string password, string firstName, string lastName)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RepasswordAsync(long userId, string oldPassword, string newPassword)
    {
        throw new NotImplementedException();
    }
}
