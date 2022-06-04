﻿using Infrastructure.Models;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace aspnetMelon.MinimalApi.EndpointDefinitions;

public class ProductDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        // GET: PRODUCTS BY PAGE
        app.MapGet("/products", GetProducts);

        async Task<IEnumerable<ProductDto>> GetProducts(IProductService productService, int page = 1, int pageSize = 20, bool onSale = false)
        {
            Func<int, int, Task<IEnumerable<ProductDto>>> GetProducts
            = onSale ? productService.GetProductsOnSale : productService.GetProducts;

            if (page == 0 || pageSize == 0)
                return await GetProducts(1, 20);
            return await GetProducts(page, pageSize);

        }

        //GET: PRODUCT BY ID
        app.MapGet("/products/{id}", async (IProductService productService, int id) =>
        {
            var product = await productService.GetProductById(id);
            return product != null ? Results.Ok(product) : Results.NotFound();
        });
        //POST: ADDS/UPDATES PRODUCT
        app.MapPost("/products/{id}", async (IProductService productService, int id, ProductDto product) =>
        {
            var success = await productService.AddOrUpdate(product);
            return success ? Results.Ok(product) : Results.BadRequest();
        });
    }

    public void DefineServices(IServiceCollection services)
    {
        
    }
}