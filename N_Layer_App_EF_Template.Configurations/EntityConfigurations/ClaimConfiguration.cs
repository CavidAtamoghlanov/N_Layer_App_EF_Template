using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Configurations.EntityConfigurations;

public class ClaimConfiguration : IEntityTypeConfiguration<Claim>
{
    public void Configure(EntityTypeBuilder<Claim> builder)
    {
        builder.Property(rc => rc.Name).IsRequired().HasMaxLength(50);
        builder.Property(rc => rc.Description).HasMaxLength(500);
        builder.Property(rc => rc.Description).HasMaxLength(500);
        builder.Property(rc => rc.Description).HasMaxLength(500);
        builder.Property(rc => rc.Description).HasMaxLength(500);
        builder.Property(rc => rc.Description).HasMaxLength(500);
    }
}
