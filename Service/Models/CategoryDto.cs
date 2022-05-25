using Domain.Models;

namespace Service.Models;

public record CategoryDto(int CategoryId, string CategoryName, string CategoryDescription, ICollection<ProductDto>? Products)
{
    

    public static implicit operator CategoryDto(Category? category) =>
        category is null ? new CategoryDto(0, "","",new List<ProductDto>()) : new (category.CategoryId,category.CategoryName,category.CategoryDescription, category.Products?.Select(p => (ProductDto)p).ToList());
}