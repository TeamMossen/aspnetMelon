namespace Domain.Configurations;

public class ProductReviewConfig : IEntityTypeConfiguration<ProductReview>
{
    public void Configure(EntityTypeBuilder<ProductReview> builder)
    {
        builder.HasKey(p =>  p.ProductId );
        builder.HasOne(p => p.Product).WithOne().HasForeignKey<ProductReview>(p => p.ProductId);
        builder.Navigation(p => p.Product).AutoInclude(false);

        builder.HasData(new ProductReview() { ProductId = 5, ReviewUri = "https://www.amazon.com/TP-Link-Deco-Whole-Home-System/dp/B06WVCB862/ref=sr_1_3?keywords=deco+m5&qid=1654024122&sr=8-3" });
    }
}