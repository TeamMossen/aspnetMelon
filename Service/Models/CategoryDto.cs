using Domain.Models;

namespace Service.Models;

public record CategoryDto(int CategoryId, string CategoryName, string CategoryDescription, ICollection<ProductDto>? Products)
{
    
    public static implicit operator CategoryDto(Category category) =>
        new (category.CategoryId,category.CategoryName,category.CategoryDescription, category.Products?.Select(p => (ProductDto) p!).ToList());
}