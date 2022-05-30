namespace Service.Models;

public record ProductDto
(int ProductId, string Name, string Description, decimal Price,
    string ImageUrl, string ImageThumbnailUrl, bool IsOnSale, decimal SalePrice, int Stock, int CategoryId, CategoryDto? Category = null)
{
    public decimal GetCurrentPrice() => IsOnSale switch
    {
        true => SalePrice,
        false => Price
    };


    public static implicit operator ProductDto?(Product? product) =>
        product is null ? null : 
            new (product.ProductId, product.Name, product.Description, product.Price, product.ImageUrl,
            product.ImageThumbnailUrl, product.IsOnSale,product.SalePrice, product.Stock, product.CategoryId, product.Category);

    public static implicit operator Product(ProductDto product) =>
        new(product.ProductId, product.Name, product.Description, product.Price, product.ImageUrl,
                product.ImageThumbnailUrl, product.IsOnSale, product.Stock, product.CategoryId, product.SalePrice);

}