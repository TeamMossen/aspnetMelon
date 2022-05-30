using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace aspnetMelon.Areas.Admin.Controllers;

[Area("Admin")]
public class OrderLogController : Controller
{
    private readonly IOrderService _orderService;

        public OrderLogController(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }
        public IActionResult Index()
        {
            var orders = _orderService.GetAllOrders();
            return View(orders);
        }

        public IActionResult OrderLogDetail(int id)
        {
            var order = _orderService.GetOrder(id);
            return View(order);
        }
    }
}
