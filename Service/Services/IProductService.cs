﻿using Service.Models;

namespace Service.Services;

public interface IProductService
{
    IEnumerable<ProductDto> GetProductsOnSale();

    ProductDto GetProductById(int id);
}