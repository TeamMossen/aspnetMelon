using Microsoft.AspNetCore.Mvc;

namespace aspnetMelon.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Details(int id)
        {
            var product = _productService.GetProductById(id);
            if (product is null)
                return NotFound();
            return View(product);
        }
    }
}
