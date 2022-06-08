using System.Collections;
using aspnetMelon.MinimalApi.Attributes;
using Domain.Migrations;
using Infrastructure.Models.Dtos;
using Infrastructure.Models.Parameters;
using Infrastructure.Models.Parameters.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApis.Extensions.Binding;

namespace aspnetMelon.MinimalApi.EndpointDefinitions;

public class ProductEndpoint : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        // GET: PRODUCTS BY PAGE AND QUERY
        app.MapGet("/products", async (IProductService productService, ProductParameters searchParameters, PageParameters pageParameters) =>
            await productService.GetProducts(pageParameters, searchParameters));

        //GET: PRODUCT BY ID
        app.MapGet("/products/{id}", async (IProductService productService, int id) =>
        {
            var product = await productService.GetProductById(id);
            return product != null ? Results.Ok(product) : Results.NotFound();
        });
        //POST: ADDS/UPDATES PRODUCT
        app.MapPost("/products/{id}", [ApiKey(Role.Administrator)] async (IProductService productService, int id, ProductDto product) =>
        {
            var success = await productService.AddOrUpdate(product);
            return success ? Results.Ok(product) : Results.BadRequest();
        });
        //DELETE: DELETES PRODUCT BY ID
        app.MapDelete("/products/{id}", [ApiKey(Role.Administrator)] async (IProductService ProductService, int id) =>
        {
            var success = await ProductService.Delete(id);
            return success ? Results.Ok() : Results.BadRequest();
        });
    }

}