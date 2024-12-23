using N_Layer_App_EF_Template.Domain.Enums;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;

public interface IAuthService
{
    Task<string> LoginAsync(string email, string password);
    Task<string> RegisterAsync(string firstName, string lastName, string? middleName, string email, string password, string? phoneNumber);
    Task<bool> RepasswordAsync(long userId, string oldPassword, string newPassword);
    Task<bool> ForgotPasswordAsync(string email);
    Task<bool> ConfirmAsync(string token, string otp, ConfirmationMethod method);
    Task<bool> LogOutAsync(long userId);
}
