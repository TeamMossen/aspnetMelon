using Microsoft.AspNetCore.Mvc;

namespace aspnetMelon.Controllers
{
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
