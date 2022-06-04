using Domain.Models.Identity;

namespace Domain.Configurations;

public class AppRoleConfig : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.HasData(
            new AppRole {Id = 1, Name = "Administrator", NormalizedName = "ADMINISTRATOR"},
            new AppRole {Id = 2, Name = "User", NormalizedName = "USER"}
        );
    }
}