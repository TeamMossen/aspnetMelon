using Domain.Models;

namespace Service.Models;

public record ProductDto
(int ProductId, string Name, string Description, decimal Price,
    string ImageUrl, string ImageThumbnailUrl, bool IsOnSale, int Stock, int CategoryId, CategoryDto? Category = null)
{
    //public CategoryDto Category { get; init; } = Category ?? new { CategoryId = CategoryId };


    public static implicit operator ProductDto?(Product? product) =>
        product is null ? null : 
            new (product.ProductId, product.Name, product.Description, product.Price, product.ImageUrl,
            product.ImageThumbnailUrl, product.IsOnSale, product.Stock, product.CategoryId, product.Category);

}