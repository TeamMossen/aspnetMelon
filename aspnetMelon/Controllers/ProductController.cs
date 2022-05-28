using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace aspnetMelon.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Details(int id)
    {
        var product = _productService.GetProductById(id);
        if (product is null)
            return NotFound();
        return View(product);
    }

    public IActionResult Products(int? categoryId = null)
    {
        var productViewModel = new ProductsViewModel()
        {
            Products = categoryId is not null
                ? _productService.GetProductsByCategory(categoryId.Value)
                : _productService.GetProducts(1, 20)
        };

        return View(productViewModel);
    }
}