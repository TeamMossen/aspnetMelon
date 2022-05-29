using Domain;
using Microsoft.EntityFrameworkCore;

namespace Service.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _appContext;

    public ProductService(AppDbContext appContext)
    {
        _appContext = appContext;
    }


    public IEnumerable<ProductDto> GetProducts(int page, int pageSize)
    {
        var pageParameters = new PageParameters(page, pageSize);

        return _appContext.Products.Select(p => (ProductDto)p)
            .Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize)
            .Take(pageParameters.PageSize);
    }

    public IEnumerable<ProductDto> GetProductsByCategory(int categoryId) 
        => _appContext.Products.Where(p => p.CategoryId == categoryId).Include(p => p.Category).Select(p => (ProductDto)p);
    public IEnumerable<ProductDto> GetProductsOnSale() 
        => _appContext.Products.Where(p => p.IsOnSale).Include(p => p.Category).Select(p => (ProductDto)p);
    public ProductDto GetProductById(int id) 
        => _appContext.Products.Where(x => x.ProductId == id).Include(p => p.Category).First();
}