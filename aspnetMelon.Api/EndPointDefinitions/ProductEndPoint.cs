using Infrastructure.Models.Dtos;
using Infrastructure.Models.Parameters;
using Infrastructure.Models.Parameters.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace aspnetMelon.MinimalApi.EndpointDefinitions;

public class ProductEndPoint : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        // GET: PRODUCTS BY PAGE
        app.MapGet("/products", GetProducts);

        //async Task<IEnumerable<ProductDto>> GetProducts(IProductService productService, int page = 1, int pageSize = 20, bool onSale = false)
        //{
        //    Func<int, int, Task<IEnumerable<ProductDto>>> GetProducts
        //    = onSale ? productService.GetProductsOnSale : productService.GetProducts;

        //    if (page == 0 || pageSize == 0)
        //        return await GetProducts(1, 20);
        //    return await GetProducts(page, pageSize);

        //}

        async Task<IEnumerable<ProductDto>> GetProducts(IProductService productService, int page, int pageSize, [FromBody]ISearchParameters searchParameters)
        {
            var products = await productService.GetProducts(new PageParameters(page, pageSize), searchParameters);
            return products;
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
        //DELETE: DELETES PRODUCT BY ID
        app.MapDelete("/products/{id}", async (IProductService ProductService, int id) =>
        {
            var success = await ProductService.Delete(id);
            return success ? Results.Ok() : Results.BadRequest();
        });
    }

    public void DefineServices(IServiceCollection services)
    {
        
    }
}