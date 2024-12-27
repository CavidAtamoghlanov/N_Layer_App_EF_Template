using N_Layer_App_EF_Template.Business.Mappings.Abstracts;
using N_Layer_App_EF_Template.Business.ServiceResults.Abstracts;
using N_Layer_App_EF_Template.Business.ServiceResults.Concretes;
using N_Layer_App_EF_Template.Business.Services.Commons;
using N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;
using N_Layer_App_EF_Template.DataAccess.UnitOfWorks.Abstracts;
using N_Layer_App_EF_Template.Domain.Enums;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Concretes;

public class AuthService : BaseService, IAuthService
{
    public AuthService(IUnitOfWork unitOfWork, IAutoMapper autoMapper) : base(unitOfWork, autoMapper)
    {
    }

    public Task<IServiceResult> ConfirmAsync(string token, string otp, ConfirmationMethod method)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> ForgotPasswordAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> LoginAsync(string email, string password)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> LogOutAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> RegisterAsync(string firstName, string lastName, string? middleName, string email, string password, string? phoneNumber)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> RepasswordAsync(long userId, string oldPassword, string newPassword)
    {
        throw new NotImplementedException();
    }
}
