namespace Domain.Configurations;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
       // builder.Navigation(c => c.Products).AutoInclude(false);
        builder.HasData(
            new Category { CategoryId = 1, CategoryName = "Mobilt", CategoryDescription = "Mobiltillbehör av alla sorter!" },
            new Category { CategoryId = 2, CategoryName = "Nätverk", CategoryDescription = "Allt för hemmanätverket!" },
            new Category { CategoryId = 3, CategoryName = "Ljud & Bild", CategoryDescription = "Allt från hörlurar till hemmabio!" },
            new Category { CategoryId = 4, CategoryName = "Meloner", CategoryDescription = "Saftiga meloner från jordens alla hörn!" }
        );
    }
}