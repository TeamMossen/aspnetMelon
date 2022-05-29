using Microsoft.AspNetCore.Mvc;

namespace aspnetMelon.Areas.Admin.Controllers;

public class ProductsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}