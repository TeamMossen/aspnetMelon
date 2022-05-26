namespace Domain.Configurations;

public class AppUserConfig : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Navigation(e => e.ShoppingCart).AutoInclude();
    }
}