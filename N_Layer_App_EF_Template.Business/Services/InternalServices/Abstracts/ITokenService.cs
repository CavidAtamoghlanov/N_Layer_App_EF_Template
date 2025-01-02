using N_Layer_App_EF_Template.Business.ServiceResults.Abstracts;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;

public interface ITokenService
{
    Task<IServiceResult> GenerateJwtTokenAsync(long userId, string username, string role);
    Task<IServiceResult> ValidRefreshTokenAsync(string refreshToken);
    Task<IServiceResult> GenerateRefreshTokenAsync();
    Task<IServiceResult> RevokeRefreshTokenAsync(string refreshToken);
    Task<IServiceResult> GetClaimsFromTokenAsync(string token);
    Task<IServiceResult> GetRolesFromTokenAsync(string token);
}
