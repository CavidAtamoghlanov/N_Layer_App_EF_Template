using N_Layer_App_EF_Template.Business.Responses;
using N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Concretes;

public class TokenService : ResponseMethods, ITokenService
{
    public Task<string> GenerateJwtTokenAsync(long userId, string username, string role)
    {
        throw new NotImplementedException();
    }

    public Task<string> GenerateRefreshTokenAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Claim>> GetClaimsFromTokenAsync(string token)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<string>> GetRolesFromTokenAsync(string token)
    {
        throw new NotImplementedException();
    }

    public Task<string> RefreshTokenAsync(string refreshToken)
    {
        throw new NotImplementedException();
    }

    public Task RevokeRefreshTokenAsync(string refreshToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ValidateTokenAsync(string token)
    {
        throw new NotImplementedException();
    }
}
