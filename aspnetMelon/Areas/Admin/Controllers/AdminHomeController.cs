using Microsoft.AspNetCore.Mvc;

namespace aspnetMelon.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
