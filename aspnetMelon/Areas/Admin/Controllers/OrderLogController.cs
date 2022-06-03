using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspnetMelon.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Administrator")]
public class OrderLogController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IProductService _productService;

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
