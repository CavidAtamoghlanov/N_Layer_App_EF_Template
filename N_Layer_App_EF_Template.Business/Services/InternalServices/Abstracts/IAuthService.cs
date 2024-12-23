using N_Layer_App_EF_Template.Domain.Enums;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;

public interface IAuthService
{
    Task<string> LoginAsync(string email, string password);
    Task<string> RegisterAsync(string email, string password, string firstName, string lastName);
    Task<bool> RepasswordAsync(long userId, string oldPassword, string newPassword);
    Task<bool> ForgotePasswordAsync(string email);
    Task<bool> ConfirmAsync(string contact, ConfirmationMethod method);
    Task<bool> LogOutAsync(long userId);
}
