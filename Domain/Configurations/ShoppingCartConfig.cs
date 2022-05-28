namespace Domain.Configurations;

public class ShoppingCartConfig : IEntityTypeConfiguration<ShoppingCart>
{
    public void Configure(EntityTypeBuilder<ShoppingCart> builder)
    {
        builder
            .HasMany(x => x.ShoppingCartItems)
            .WithOne(x => x.ShoppingCart)
            .OnDelete(DeleteBehavior.Cascade);
    }
}