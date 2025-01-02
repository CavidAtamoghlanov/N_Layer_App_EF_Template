using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using N_Layer_App_EF_Template.Business.DTOs.TokenDTOs;
using N_Layer_App_EF_Template.Business.Mappings.Abstracts;
using N_Layer_App_EF_Template.Business.ServiceResults.Abstracts;
using N_Layer_App_EF_Template.Business.ServiceResults.Concretes;
using N_Layer_App_EF_Template.Business.Services.Commons;
using N_Layer_App_EF_Template.Business.Services.InternalServices.Abstracts;
using N_Layer_App_EF_Template.DataAccess.UnitOfWorks.Abstracts;
using N_Layer_App_EF_Template.Domain.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace N_Layer_App_EF_Template.Business.Services.InternalServices.Concretes;

public class TokenService : BaseService, ITokenService
{
    private readonly JwtSettings _jwtSettings;
    public TokenService(IUnitOfWork unitOfWork,
                        IAutoMapper autoMapper,
                        IOptions<JwtSettings> jwtSettings) : base(unitOfWork, autoMapper)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<IServiceResult> GenerateJwtTokenAsync(long userId, string username, string role)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, username),
            new Claim(ClaimTypes.Role, role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var tokenOptions = new JwtSecurityToken
        (
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_jwtSettings.ExpiryMinutes)),
            signingCredentials: signingCredentials
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        var accesstoken = tokenHandler.WriteToken(tokenOptions);
        var refreshToken = await GenerateRefreshTokenAsync() as ServiceResultWithObject<string>;

        var tokenResult = TokenResult.Create(accesstoken, refreshToken?.ResultObj!, _jwtSettings.ExpiryMinutes);

        return Success<TokenResult>(tokenResult);
    }

    public async Task<IServiceResult> GenerateRefreshTokenAsync()
    {
        string refreshToken = "";
        var randomNumber = new byte[32];

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            refreshToken = Convert.ToBase64String(randomNumber);
        };

        return Success<string>(refreshToken);
    }

    public async Task<IServiceResult> GetClaimsFromTokenAsync(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var claims = jwtToken.Claims;
            var username = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            return Success<IEnumerable<Claim>>(claims);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    public async Task<IServiceResult> GetRolesFromTokenAsync(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var claims = jwtToken.Claims;

            var roles = claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();

            return Success<IEnumerable<string>>(roles);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
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
