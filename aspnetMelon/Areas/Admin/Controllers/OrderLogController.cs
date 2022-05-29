using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace aspnetMelon.Controllers.Admin
{
    [Area("Admin")]
    public class OrderLogController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderLogController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            var orders = _orderService.GetAllOrders();
            return View(orders);
        }
    }
}
