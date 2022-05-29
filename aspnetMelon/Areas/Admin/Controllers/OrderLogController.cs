using Microsoft.AspNetCore.Mvc;

namespace aspnetMelon.Controllers.Admin
{
    public class OrderLogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
