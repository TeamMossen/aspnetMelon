

using Domain.Models.Identity;

namespace Domain.Configurations;

public class AppUserConfig : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        //builder.Property(u => u.ShoppingCart)
        //builder.HasOne(x => x.ShoppingCart).

       // builder.Property(u => u.ShoppingCartId).HasDefaultValue(0);
       builder.HasIndex(u => u.ApiKey).IsUnique();

        builder.Navigation(e => e.ShoppingCart).AutoInclude();
      
    }
}