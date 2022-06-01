using Microsoft.AspNetCore.Mvc;

namespace aspnetMelon.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IProductReviewService _productReviewService;

    public ProductController(IProductService productService, ICategoryService categoryService, IProductReviewService productReviewService)
    {
        _productService = productService;
        _categoryService = categoryService;
        _productReviewService = productReviewService;
    }

    public async Task<IActionResult> Details(int id)
    {
        var product = _productService.GetProductById(id);
        if (product is null)
            return NotFound();

        var productReviews = await _productReviewService.GetReviews(5);
        var productDetailViewModel = new ProductDetailViewModel { Product = product, ProductReviews = productReviews };
        return View(productDetailViewModel);
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