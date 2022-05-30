using System.Diagnostics;
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
    public IActionResult AddOrEdit(int? id)
    {
        if (id is null)
            return View();
        var product = _productService.GetProductById(id.Value);

        return product is not null ? View(product) : NotFound($"No product with id:{id} found");
    }

    public async Task<IActionResult> Delete(int? id)
    {
        //var customer = await _context.Customers.FindAsync(id);
        //_context.Customers.Remove(customer);
        //await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}