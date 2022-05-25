﻿using Domain.Models;

namespace Service.Models;

public record ProductDto
(int ProductId, string Name, string Description, decimal Price,
    string ImageUrl, string ImageThumbnailUrl, bool IsOnSale, int Stock, CategoryDto Category)
{
    public static implicit operator ProductDto(Product product) =>
        new(product.ProductId, product.Name, product.Description, product.Price, product.ImageUrl,
            product.ImageThumbnailUrl, product.IsOnSale, product.Stock, (CategoryDto)product.Category);
}