using Domain;
using Microsoft.EntityFrameworkCore;
using Service.Models;

namespace Service.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _appContext;

    public ProductService(AppDbContext appContext)
    {
        _appContext = appContext;
    }

    public IEnumerable<ProductDto> GetProductsOnSale() //.Include(p => p.Category)
    {
        var e = _appContext.Products.Where(p => p.IsOnSale).Include(p => p.Category);

        var s = e.Select(p => (ProductDto) p).ToList();

        return s;
        //return new List<ProductDto>();
    }

    public ProductDto GetProductById(int id)
    {
        return _appContext.Products.Find(id);
    }
    // => _appContext.Products.Where(p => p.IsOnSale).Include(p => p.Category).Select(p => (ProductDto)p);
}