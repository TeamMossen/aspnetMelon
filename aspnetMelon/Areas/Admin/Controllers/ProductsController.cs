using Microsoft.AspNetCore.Mvc;

namespace aspnetMelon.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductsController : Controller
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        return View(new ProductsViewModel
        {
            Products = await _productService.GetProducts(1, 20)
        });
    }
    public IActionResult AddOrEdit(int id = 0)
    {
        //if (id == 0)
        //    return View(new Customer());
        //else
        //    return View(_context.Customers.Find(id));
        return View();
    }

    public async Task<IActionResult> Delete(int? id)
    {
        //var customer = await _context.Customers.FindAsync(id);
        //_context.Customers.Remove(customer);
        //await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}