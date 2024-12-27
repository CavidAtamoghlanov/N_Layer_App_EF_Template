
using Microsoft.EntityFrameworkCore;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Configurations.SeedDatas;

public static class SeedDataManager
{
    public static void ApplySeedData(ModelBuilder modelBuilder)
    {
        var claims = GetClaims();
        modelBuilder.Entity<Claim>().HasData(claims);

        var roles = GetRoles();
        modelBuilder.Entity<Role>().HasData(roles);

        var users = GetUsers();
        modelBuilder.Entity<User>().HasData(users);

        var userLogins = GetUserLogins();
        modelBuilder.Entity<UserLogin>().HasData(userLogins);

        var userTokens = GetUserTokens();
        modelBuilder.Entity<UserToken>().HasData(userTokens);

        ApplyManyToManyMappings(modelBuilder, claims, roles, users);
    }

    private static List<Claim> GetClaims()
    {
        return new List<Claim>
            {
                new Claim { Id = 1, Name = "ManageUsers", Description = "Permission to manage users", CreatedDate = DateTime.UtcNow },
                new Claim { Id = 2, Name = "ViewReports", Description = "Permission to view reports", CreatedDate = DateTime.UtcNow },
                new Claim { Id = 3, Name = "EditContent", Description = "Permission to edit content", CreatedDate = DateTime.UtcNow }
            };
    }

    private static List<Role> GetRoles()
    {
        return new List<Role>
            {
                new Role { Id = 1, Name = "Admin", Description = "Administrator role", CreatedDate = DateTime.UtcNow },
                new Role { Id = 2, Name = "Moderator", Description = "Moderator role", CreatedDate = DateTime.UtcNow },
                new Role { Id = 3, Name = "User", Description = "Standard user role", CreatedDate = DateTime.UtcNow }
            };
    }

    private static List<User> GetUsers()
    {
        return new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    MiddleName = "Michael",
                    Email = "john.doe@example.com",
                    EmailComfirmed = true,
                    BirthDate = new DateTime(1990, 5, 20),
                    AccessFailedCount = 0,
                    LockOutEnabled = false,
                    PasswordHash = "hashed_password_1",
                    PhoneNumber = "+123456789",
                    PhoneNumberConfirmed = true,
                    Otp = "1234",
                    OtpExpiration = DateTime.UtcNow.AddMinutes(5),
                    OtpSendDate = DateTime.UtcNow,
                    OtpVerificationMethod = Domain.Enums.ConfirmationMethod.Phone,
                    IsDeleted = false,
                    DeletedDate = null,
                    IsPermanently = false,
                    CreatedDate = DateTime.UtcNow
                },
                new User
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    MiddleName = "Elizabeth",
                    Email = "jane.smith@example.com",
                    EmailComfirmed = true,
                    BirthDate = new DateTime(1985, 11, 15),
                    AccessFailedCount = 1,
                    LockOutEnabled = true,
                    PasswordHash = "hashed_password_2",
                    PhoneNumber = "+987654321",
                    PhoneNumberConfirmed = true,
                    Otp = "5678",
                    OtpExpiration = DateTime.UtcNow.AddMinutes(10),
                    OtpSendDate = DateTime.UtcNow,
                    OtpVerificationMethod = Domain.Enums.ConfirmationMethod.Email,
                    IsDeleted = false,
                    DeletedDate = null,
                    IsPermanently = false,
                    CreatedDate = DateTime.UtcNow
                },
                new User
                {
                    Id = 3,
                    FirstName = "Alice",
                    LastName = "Brown",
                    MiddleName = "Marie",
                    Email = "alice.brown@example.com",
                    EmailComfirmed = false,
                    BirthDate = new DateTime(1995, 7, 10),
                    AccessFailedCount = 2,
                    LockOutEnabled = false,
                    PasswordHash = "hashed_password_3",
                    PhoneNumber = "+555123456",
                    PhoneNumberConfirmed = false,
                    Otp = "91011",
                    OtpExpiration = DateTime.UtcNow.AddMinutes(15),
                    OtpSendDate = DateTime.UtcNow,
                    OtpVerificationMethod = Domain.Enums.ConfirmationMethod.Phone,
                    IsDeleted = false,
                    DeletedDate = null,
                    IsPermanently = false,
                    CreatedDate = DateTime.UtcNow
                }
            };
    }

    private static List<UserLogin> GetUserLogins()
    {
        return new List<UserLogin>
            {
                new UserLogin { Id = 1, ProviderName = "Google", ProviderKey = "google-key-1", UserId = 1, IsDeleted = false, DeletedDate = null, IsPermanently = false, CreatedDate = DateTime.UtcNow },
                new UserLogin { Id = 2, ProviderName = "Facebook", ProviderKey = "facebook-key-2", UserId = 2, IsDeleted = false, DeletedDate = null, IsPermanently = false, CreatedDate = DateTime.UtcNow },
                new UserLogin { Id = 3, ProviderName = "Twitter", ProviderKey = "twitter-key-3", UserId = 3, IsDeleted = false, DeletedDate = null, IsPermanently = false, CreatedDate = DateTime.UtcNow }
            };
    }

    private static List<UserToken> GetUserTokens()
    {
        return new List<UserToken>
            {
                new UserToken { Id = "token-1", Key = "refresh", Value = "token-value-1", UserId = 1, ExpireDate = DateTime.UtcNow.AddDays(7), CreatedDate = DateTime.UtcNow },
                new UserToken { Id = "token-2", Key = "refresh", Value = "token-value-2", UserId = 2, ExpireDate = DateTime.UtcNow.AddDays(7), CreatedDate = DateTime.UtcNow },
                new UserToken { Id = "token-3", Key = "refresh", Value = "token-value-3", UserId = 3, ExpireDate = DateTime.UtcNow.AddDays(7), CreatedDate = DateTime.UtcNow }
            };
    }

    private static void ApplyManyToManyMappings(ModelBuilder modelBuilder, List<Claim> claims, List<Role> roles, List<User> users)
    {
        modelBuilder.Entity<Role>()
            .HasMany(r => r.Claims)
            .WithMany(c => c.Roles)
            .UsingEntity(j => j.HasData(
                new { ClaimsId = claims[0].Id, RolesId = roles[0].Id },
                new { ClaimsId = claims[1].Id, RolesId = roles[1].Id },
                new { ClaimsId = claims[2].Id, RolesId = roles[2].Id }
            ));

        modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity(j => j.HasData(
                new { UsersId = users[0].Id, RolesId = roles[0].Id },
                new { UsersId = users[1].Id, RolesId = roles[1].Id },
                new { UsersId = users[2].Id, RolesId = roles[2].Id }
            ));
    }
}
