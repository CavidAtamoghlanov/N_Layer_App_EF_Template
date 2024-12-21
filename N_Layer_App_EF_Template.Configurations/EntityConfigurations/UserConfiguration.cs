using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Configurations.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(150);

        builder.HasQueryFilter(u => !u.IsDeleted);

        builder.HasMany(u => u.UserLogins)
               .WithOne(ul => ul.User)
               .HasForeignKey(ul => ul.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.UserTokens)
               .WithOne(ut => ut.User)
               .HasForeignKey(ut => ut.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
