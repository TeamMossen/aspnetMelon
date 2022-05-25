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

    public IEnumerable<ProductDto> GetProductsOnSale() 
        => _appContext.Products.Where(p => p.IsOnSale).Include(p => p.Category).Select(p => (ProductDto)p);

    public ProductDto GetProductById(int id) 
        => _appContext.Products.Where(x => x.ProductId == id).Include(p => p.Category).First();
}