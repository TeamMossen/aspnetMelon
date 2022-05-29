using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace aspnetMelon.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
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
    public ViewResult List(int categoryId)
    {

        IEnumerable<ProductDto> products;
        string currentCategory;

        if (categoryId == 0)
        {
            products = _productService.GetProducts(1, 20).OrderBy(p => p.ProductId);
            currentCategory = "All Products";
        }
        else
        {
            products = _productService.GetProductsByCategory(categoryId);

            currentCategory = _categoryService.GetCategoryByCategoryId(categoryId).CategoryName;
        }
        return View(new ProductListViewModel
        {
            Products = products,
            CurrentCategory = currentCategory
        });
    }

}