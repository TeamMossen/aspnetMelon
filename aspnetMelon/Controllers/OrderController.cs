﻿using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

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
    public IActionResult Checkout(Order order)
    {
        //_shoppingCartService.SetShoppingCartItems(_shoppingCartService.GetShoppingCartItems(user).AsEnumerable());

        if (_shoppingCartService.GetShoppingCartItems().Count == 0)
        {
            ModelState.AddModelError("", "Your cart is empty!");
        }
        if (ModelState.IsValid)
        {
            //_orderRepository.CreatOrder(order);
            _shoppingCartService.ClearCart();
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