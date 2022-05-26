using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspnetMelon.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderService orderService, ShoppingCart shoppingCart)
        {
            _orderService = orderService;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Youe cart is empty");
            }
            if (ModelState.IsValid)
            {
                _orderRepository.CreatOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thank you for your order. Enjoy your candy";
            return View();
        }
    }
}
