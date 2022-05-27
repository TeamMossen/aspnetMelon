

namespace Domain.Configurations;

public class AppUserConfig : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        //builder.Property(u => u.ShoppingCart)
        //builder.HasOne(x => x.ShoppingCart).

       // builder.Property(u => u.ShoppingCartId).HasDefaultValue(0);

        builder.Navigation(e => e.ShoppingCart).AutoInclude();
      
    }
}