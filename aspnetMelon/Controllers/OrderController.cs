using Infrastructure.Models.Dtos;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspnetMelon.Controllers;

[Authorize]
public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IShoppingCartService _shoppingCartService;

    public OrderController(IOrderService orderService, IShoppingCartService shoppingCartService)
    {
        _orderService = orderService;
        _shoppingCartService = shoppingCartService;
    }

    public IActionResult Checkout()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Checkout(OrderDto order)
    {
        //_shoppingCartService.SetShoppingCartItems(_shoppingCartService.GetShoppingCartItems(user).AsEnumerable());
        ModelState.Remove(nameof(order.OrderDetails));
        if (_shoppingCartService.GetShoppingCartItems().Count == 0)
        {
            ModelState.AddModelError("", "Your cart is empty!");
        }
        if (ModelState.IsValid)
        {
            _orderService.CreateOrder(order);
            _shoppingCartService.ClearCart();
            return RedirectToAction("CheckoutComplete");
        }

        return View(order);
    }

    public IActionResult CheckoutComplete()
    {
        ViewBag.CheckoutCompleteMessage = "Thank you for your order!";
        return View();
    }
}