using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace aspnetMelon.Controllers;

public class ShoppingCartController : Controller
{
    private readonly IProductService _productService;
    private readonly IShoppingCartService _shoppingCartService;

    public ShoppingCartController(IProductService productService, IShoppingCartService shoppingCartService)
    {
        _productService = productService;
        _shoppingCartService = shoppingCartService;
    }

    public ViewResult Index()
    {
        //_shoppingCartService.GetCart(this.User);
        //_shoppingCartService.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

        var shoppingCartViewModel = new ShoppingCartViewModel
        {
            ShoppingCart = _shoppingCartService.GetCart(),
            ShoppingCartTotal = _shoppingCartService.GetShoppingCartTotal()
        };
        
        return View(shoppingCartViewModel);
    }

    public RedirectToActionResult AddToShoppingCart(int productId)
    {
        //var selectedCandy = _candyRepositoyr.GetAllCandy.FirstOrDefault(c => c.CandyId == candyId);

        //if (selectedCandy != null)
        //{
        _shoppingCartService.AddToCart(productId, 1);
       // }
       
        return RedirectToAction("Index");
    }

    public RedirectToActionResult RemoveFromShoppingCart(int productId)
    {
       // var selectedCandy = _candyRepositoyr.GetAllCandy.FirstOrDefault(c => c.CandyId == candyId);

        //if (selectedCandy != null)
        //{
            _shoppingCartService.RemoveFromCart(productId);
        //}

        return RedirectToAction("Index");
    }

    public RedirectToActionResult ClearCart()
    {
        _shoppingCartService.ClearCart();
        return RedirectToAction("Index");
    }
}


