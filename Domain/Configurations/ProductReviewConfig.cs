namespace Domain.Configurations;

public class ProductReviewConfig : IEntityTypeConfiguration<ProductReview>
{
    public void Configure(EntityTypeBuilder<ProductReview> builder)
    {
        builder.HasKey(p => p.ProductId);
        builder.HasOne(p => p.Product).WithOne().HasForeignKey<ProductReview>(p => p.ProductId);
        builder.Navigation(p => p.Product).AutoInclude(false);

        builder.HasData(
            new ProductReview() { ProductId = 5, ReviewUri = "https://www.amazon.com/TP-Link-Deco-Whole-Home-System/dp/B06WVCB862/ref=sr_1_3?keywords=deco+m5&qid=1654024122&sr=8-3" },
            new ProductReview() { ProductId = 1, ReviewUri = "https://www.amazon.com/beyerdynamic-770-PRO-Studio-Headphone/dp/B0016MNAAI/ref=sr_1_1?crid=11D3FY6ZK31AM&keywords=dt770+pro+80+ohm&qid=1654074204&sprefix=dt770+pro+80+ohm%2Caps%2C194&sr=8-1" },
            new ProductReview() { ProductId = 2, ReviewUri = "https://www.amazon.com/Sonos-Arc-Premium-Soundbar-Movies/dp/B087CD7H2G/ref=sr_1_3?crid=3HCLLN96MF1NX&keywords=sonos+arc&qid=1654074219&sprefix=sonos+ar%2Caps%2C215&sr=8-3" },
            new ProductReview() { ProductId = 3, ReviewUri = "https://www.amazon.com/LG-OLED55C1PUB-Alexa-Built-Smart/dp/B08WFV7L3N/ref=sr_1_1?crid=LQKW12KEDK9T&keywords=lg+c1&qid=1654074240&sprefix=lg+c%2Caps%2C207&sr=8-1" },
            new ProductReview() { ProductId = 4, ReviewUri = "https://www.amazon.com/Synology-Bay-DiskStation-DS220-Diskless/dp/B087ZCBWFH/ref=sr_1_2?crid=YBRJ8TD03N5C&keywords=synology+ds220%2B&qid=1654074261&sprefix=synology+ds220%2Caps%2C235&sr=8-2" },
            new ProductReview() { ProductId = 6, ReviewUri = "https://www.amazon.com/ASUS-AX1800-WiFi-Router-RT-AX55/dp/B08J6CFM39/ref=sr_1_3?crid=QTUQDW513R35&keywords=rt-ax55&qid=1654074279&sprefix=rt-ax5%2Caps%2C194&sr=8-3" },
            new ProductReview() { ProductId = 7, ReviewUri = "https://www.amazon.com/Solar-Power-Charger-Flashlight-Splashproof/dp/B07FDXDB3W/ref=sr_1_3?keywords=power+bank+solar+charger&qid=1654074318&sprefix=powerbank+solar%2Caps%2C208&sr=8-3" },
            new ProductReview() { ProductId = 8, ReviewUri = "https://www.amazon.com/iFixit-Pro-Tech-Toolkit-Electronics/dp/B01GF0KV6G/ref=sr_1_2_sspa?crid=1KSXA0TK748ZL&keywords=ifixit+pro+tech+toolkit&qid=1654074336&sprefix=ifixit+pro+tech+toolk%2Caps%2C198&sr=8-2-spons&psc=1&smid=A3JGOE00MHF9QZ&spLa=ZW5jcnlwdGVkUXVhbGlmaWVyPUFOMzlCWjc0Mk1JTEMmZW5jcnlwdGVkSWQ9QTA3MjE3NzhRTzMzSjRYOUVHVDQmZW5jcnlwdGVkQWRJZD1BMDA3MTU4NjJSSTIzNkVWSUxUOVUmd2lkZ2V0TmFtZT1zcF9hdGYmYWN0aW9uPWNsaWNrUmVkaXJlY3QmZG9Ob3RMb2dDbGljaz10cnVl" },
            new ProductReview() { ProductId = 9, ReviewUri = "https://www.amazon.com/Samsung-Factory-Unlocked-Smartphone-Intelligent/dp/B09BFRV59N/ref=sr_1_1_sspa?crid=1QAPS0XSSUG9J&keywords=galaxy+s21+fe&qid=1654074353&sprefix=galaxy+s21+%2Caps%2C241&sr=8-1-spons&psc=1&spLa=ZW5jcnlwdGVkUXVhbGlmaWVyPUEyOTdSOUpXME1JNDhEJmVuY3J5cHRlZElkPUEwOTE5MjY1MUVaVkEyNFFWODVSSSZlbmNyeXB0ZWRBZElkPUEwNjI4MTA1MzAzVUREM0UxSFpBVSZ3aWRnZXROYW1lPXNwX2F0ZiZhY3Rpb249Y2xpY2tSZWRpcmVjdCZkb05vdExvZ0NsaWNrPXRydWU=" }
        );
    }
}
