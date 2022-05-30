﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspnetMelon.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles="Administrator")]
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
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddOrEdit(ProductDto product)
    {
        //_shoppingCartService.SetShoppingCartItems(_shoppingCartService.GetShoppingCartItems(user).AsEnumerable());
        ModelState.Remove(nameof(product.Category));
        if (ModelState.IsValid)
        {
            _productService.AddOrUpdate(product);
            return RedirectToAction("Index");
        }

        return View(product);
    }
    //public async Task<IActionResult> AddOrEdit([Bind("Id,Name,Address")] Customer customer)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        if (customer.Id == 0)
    //            _context.Add(customer);
    //        else
    //            _context.Update(customer);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }
    //    return View(customer);
    //}

    
    public async Task<IActionResult> Delete(int? id)
    {
        //var customer = await _context.Customers.FindAsync(id);
        //_context.Customers.Remove(customer);
        //await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}