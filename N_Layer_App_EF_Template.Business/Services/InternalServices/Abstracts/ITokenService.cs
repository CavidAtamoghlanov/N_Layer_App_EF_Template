using N_Layer_App_EF_Template.Business.ServiceResults.Abstracts;
using N_Layer_App_EF_Template.Business.ServiceResults.Concretes;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;

public interface ITokenService
{
    Task<IServiceResult> GenerateJwtTokenAsync(long userId, string username, string role);
    Task<IServiceResult> ValidateTokenAsync(string token);
    Task<IServiceResult> RefreshTokenAsync(string refreshToken);
    Task<IServiceResult> GenerateRefreshTokenAsync();
    Task<IServiceResult> RevokeRefreshTokenAsync(string refreshToken);
    Task<IServiceResult> GetClaimsFromTokenAsync(string token);
    Task<IServiceResult> GetRolesFromTokenAsync(string token);
}
