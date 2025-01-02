namespace N_Layer_App_EF_Template.Business.DTOs.TokenDTOs;

public class TokenResult
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public int ExpiryMinutes { get; set; }

    public static TokenResult Create(string accessToken, string refreshToken, int expiryMinutes)
    {
        return new TokenResult
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            ExpiryMinutes = expiryMinutes
        };
    }

}
