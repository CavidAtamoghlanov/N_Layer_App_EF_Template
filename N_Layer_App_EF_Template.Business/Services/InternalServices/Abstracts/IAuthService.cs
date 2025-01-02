using N_Layer_App_EF_Template.Business.ServiceResults.Abstracts;
using N_Layer_App_EF_Template.Business.ServiceResults.Concretes;
using N_Layer_App_EF_Template.Domain.Enums;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;

public interface IAuthService
{
    Task<IServiceResult> LoginAsync(string email, string password);
    Task<IServiceResult> RegisterAsync(string firstName, string lastName, string? middleName, string email, string password, string? phoneNumber);
    Task<IServiceResult> RepasswordAsync(long userId, string oldPassword, string newPassword);
    Task<IServiceResult> ForgotPasswordAsync(string email);
    Task<IServiceResult> ConfirmAsync(string token, string otp, ConfirmationMethod method);
    Task<IServiceResult> LogOutAsync(long userId);
}
