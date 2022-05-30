using Microsoft.AspNetCore.Mvc;

namespace aspnetMelon.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}