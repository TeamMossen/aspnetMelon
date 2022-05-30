using aspnetMelon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace aspnetMelon.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService _productService;

    public HomeController(ILogger<HomeController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }
    public IActionResult Index()
    {
        var homeViewModel = new HomeViewModel { ProductsOnSale = _productService.GetProductsOnSale() };
        return View(homeViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}