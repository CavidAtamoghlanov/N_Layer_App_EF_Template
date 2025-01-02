namespace N_Layer_App_EF_Template.Business.Helpers;

using BCrypt.Net;

public static class PasswordHelper
{
    public static string HashPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentException("Password cannot be null or empty", nameof(password));

        return BCrypt.HashPassword(password);
    }

    public static bool VerifyPassword(string plainPassword, string hashedPassword)
    {
        if (string.IsNullOrEmpty(plainPassword) || string.IsNullOrEmpty(hashedPassword))
            throw new ArgumentException("Password and hashed password cannot be null or empty");

        return BCrypt.Verify(plainPassword, hashedPassword);
    }
}
