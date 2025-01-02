using N_Layer_App_EF_Template.Business.Mappings.Abstracts;
using N_Layer_App_EF_Template.Business.ServiceResults.Abstracts;
using N_Layer_App_EF_Template.Business.ServiceResults.Concretes;
using N_Layer_App_EF_Template.Business.Services.Commons;
using N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;
using N_Layer_App_EF_Template.DataAccess.UnitOfWorks.Abstracts;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Concretes;

public class TokenService : BaseService, ITokenService
{
    public TokenService(IUnitOfWork unitOfWork, IAutoMapper autoMapper) : base(unitOfWork, autoMapper)
    {
    }

    public Task<IServiceResult> GenerateJwtTokenAsync(long userId, string username, string role)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> GenerateRefreshTokenAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> GetClaimsFromTokenAsync(string token)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> GetRolesFromTokenAsync(string token)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> RefreshTokenAsync(string refreshToken)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> RevokeRefreshTokenAsync(string refreshToken)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResult> ValidateTokenAsync(string token)
    {
        throw new NotImplementedException();
    }
}
