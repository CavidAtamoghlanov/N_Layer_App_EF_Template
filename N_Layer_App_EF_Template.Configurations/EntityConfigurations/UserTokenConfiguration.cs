using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Configurations.EntityConfigurations;

public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.HasKey(ut => ut.Id);
        builder.Property(ut => ut.Key).IsRequired().HasMaxLength(100);
        builder.Property(ut => ut.Value).IsRequired().HasMaxLength(200);
        builder.Property(ut => ut.UserId).IsRequired(false);
        builder.Property(ut => ut.User).IsRequired(false);
    }
}
