using Microsoft.AspNetCore.Mvc;

namespace aspnetMelon.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;

        public ShoppingCartController(IProductService productService)
        {
            _productService = productService;
        }

        //public IActionResult AddToShoppingCart()
        //{

        //}
    }
}
