using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Configurations.EntityConfigurations;

public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.HasKey(rc => rc.Id);
        builder.Property(rc => rc.Name).IsRequired().HasMaxLength(50);
        builder.Property(rc => rc.Description).HasMaxLength(500);
    }
}
