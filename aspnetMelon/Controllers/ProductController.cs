using Microsoft.AspNetCore.Mvc;

namespace aspnetMelon.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IReviewService _reviewService;

    public ProductController(IProductService productService, ICategoryService categoryService, IReviewService reviewService)
    {
        _productService = productService;
        _categoryService = categoryService;
        _reviewService = reviewService;
    }

    public IActionResult Details(int id)
    {
        var product = _productService.GetProductById(id);
        if (product is null)
            return NotFound();
        var p = _reviewService.GetReviews(5).Result;
        return View(product);
    }

    public IActionResult Products(int? categoryId = null)
    {
        var productsViewModel = new ProductsViewModel();
        if (categoryId is not null)
        {
            productsViewModel.CurrentCategory = _categoryService.GetCategoryByCategoryId(categoryId.Value)?.CategoryName ?? productsViewModel.CurrentCategory;
            productsViewModel.Products = _productService.GetProductsByCategory(categoryId.Value);

            return productsViewModel.Products.Any() ? View(productsViewModel) : RedirectToAction(nameof(Products));
        }

        productsViewModel.Products = _productService.GetProducts(1, 20).Result;
        return View(productsViewModel);
    }

    //public ViewResult List(int categoryId)
    //{

    //    IEnumerable<ProductDto> products;
    //    string currentCategory;

    //    if (categoryId == 0)
    //    {
    //        products = _productService.GetProducts(1, 20).OrderBy(p => p.ProductId);
    //        currentCategory = "All Products";
    //    }
    //    else
    //    {
    //        products = _productService.GetProductsByCategory(categoryId);

    //        currentCategory = _categoryService.GetCategoryByCategoryId(categoryId).CategoryName;
    //    }
    //    return View(new ProductsViewModel
    //    {
    //        Products = products,
    //        CurrentCategory = currentCategory
    //    });
    //}

}