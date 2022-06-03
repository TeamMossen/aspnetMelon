using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Infrastructure.Services.Interfaces;

namespace aspnetMelon.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService _productService;
    private readonly IProductReviewService _reviewService;

    public HomeController(ILogger<HomeController> logger, IProductService productService, IProductReviewService reviewService)
    {
        _logger = logger;
        _productService = productService;
        _reviewService = reviewService;
    }
    public async Task<IActionResult> Index()
    {
        //var test = await _reviewService.GetReviews(5);
        var homeViewModel = new HomeViewModel { ProductsOnSale = await _productService.GetProductsOnSale() };

        return View(homeViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}