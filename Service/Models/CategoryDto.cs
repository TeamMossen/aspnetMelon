namespace Infrastructure.Models;

public record CategoryDto(int CategoryId, string CategoryName, string CategoryDescription, ICollection<ProductDto>? Products = null)
{

    public static implicit operator CategoryDto?(Category? category) =>
        category is null ? null : new (category.CategoryId,category.CategoryName,category.CategoryDescription);

    //public static implicit operator CategoryDto(Category category) =>
    //    new(category.CategoryId, category.CategoryName, category.CategoryDescription, category.Products?.Select(p => (ProductDto)p!).ToList());
}