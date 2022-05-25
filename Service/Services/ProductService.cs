using Domain;
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
        =>_appContext.Products.Where(p => p.IsOnSale).Select(p => (ProductDto)p);
}