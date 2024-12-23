using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;

public interface ITokenService
{
    Task<string> GenerateJwtTokenAsync(long userId, string username, string role);
    Task<bool> ValidateTokenAsync(string token);
    Task<string> RefreshTokenAsync(string refreshToken);
    Task<string> GenerateRefreshTokenAsync();
    Task RevokeRefreshTokenAsync(string refreshToken);

    Task<IEnumerable<Claim>> GetClaimsFromTokenAsync(string token);
    Task<IEnumerable<string>> GetRolesFromTokenAsync(string token);
}