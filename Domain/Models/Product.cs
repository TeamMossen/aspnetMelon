namespace Domain.Models;

public class Product
{
    internal Product(){}

    public Product(int productId, string name, string description, decimal price, string imageUrl, string imageThumbnailUrl, bool isOnSale, int stock, int categoryId, decimal salePrice = 0)
    {
        ProductId = productId;
        Name = name;
        Description = description;
        CategoryId = categoryId;
        Stock = stock;
        IsOnSale = isOnSale;
        Price = price;
        ImageThumbnailUrl = imageThumbnailUrl;
        ImageUrl = imageUrl;
    }

    public int ProductId { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; } 
    public string ImageUrl { get; set; } = default!;
    public string ImageThumbnailUrl { get; set; } = default!;
    public bool IsOnSale { get; set; } 
    public decimal SalePrice { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; } 
    public virtual Category Category { get; set; } = default!;

}