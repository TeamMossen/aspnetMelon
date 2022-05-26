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
            ShoppingCart = _shoppingCart,
            ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
        };

        return View(shoppingCartViewModel);
    }

    public RedirectToActionResult AddToShoppingCart(int candyId)
    {
        var selectedCandy = _candyRepositoyr.GetAllCandy.FirstOrDefault(c => c.CandyId == candyId);

        if (selectedCandy != null)
        {
            _shoppingCart.AddToCart(selectedCandy, 1);
        }

        return RedirectToAction("Index");
    }

    public RedirectToActionResult RemoveFromShoppingCar(int candyId)
    {
        var selectedCandy = _candyRepositoyr.GetAllCandy.FirstOrDefault(c => c.CandyId == candyId);

        if (selectedCandy != null)
        {
            _shoppingCart.RemoveFromCart(selectedCandy);
        }

        return RedirectToAction("Index");
    }

    public RedirectToActionResult clearCart()
    {
        _shoppingCart.ClearCart();
        return RedirectToAction("Index");
    }
}

}
