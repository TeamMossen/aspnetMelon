using Domain.Models.Identity;

namespace Domain.Configurations;

public class AppRoleConfig : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.HasData(
            new {Id = 1, Name = "Administrator"},
            new {Id = 2, Name = "User"}
        );
    }
}