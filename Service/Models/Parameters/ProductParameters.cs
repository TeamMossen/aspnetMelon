using System.Reflection;
using Infrastructure.Models.Parameters.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Models.Parameters;

public class ProductParameters : ISearchParameters
{
    public string SearchTerm { get; set; } = default!;
    public bool IsOnSale { get; set; } = false;
    public bool IsInStock { get; set; } = false;
    public string CategoryName { get; set; } = default!;
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }

    public static ValueTask<ProductParameters?> BindAsync(HttpContext httpContext, ParameterInfo parameter)
    {
        decimal.TryParse(httpContext.Request.Query["min-price"], out var minPrice);
        decimal.TryParse(httpContext.Request.Query["max-price"], out var maxPrice);

        return ValueTask.FromResult<ProductParameters?>(
            new ProductParameters
            {
                SearchTerm = httpContext.Request.Query["search-term"],
                IsOnSale = httpContext.Request.Query["on-sale"] == "true",
                IsInStock =httpContext.Request.Query["in-stock"] == "true",
                CategoryName = httpContext.Request.Query["category-name"],
                 MinPrice = minPrice,
                 MaxPrice = maxPrice
            }
        );
    }
}