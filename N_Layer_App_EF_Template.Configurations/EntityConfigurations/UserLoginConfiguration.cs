using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Configurations.EntityConfigurations;

public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.HasKey(ul => ul.Id);
        builder.Property(ul => ul.ProviderName).IsRequired().HasMaxLength(100);
        builder.Property(ul => ul.ProviderKey).IsRequired().HasMaxLength(200);

        builder.HasQueryFilter(ul => !ul.IsDeleted);
    }
}
