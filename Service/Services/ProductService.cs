using Infrastructure.Models;
using Infrastructure.Services.Interfaces;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _appContext;

    public ProductService(AppDbContext appContext)
    {
        _appContext = appContext;
    }
    public async Task<bool> AddOrUpdate(ProductDto product)
    {
        //TODO Fix not updating DB
            //Product p = product;
            //p.Category = _appContext.Categories!.Find(p.CategoryId)!;
        Product p = product;
        _appContext.Products.Update(p);
        //_appContext.SaveChanges();
        return await _appContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int id) 
        => await _appContext.Products.DeleteByKeyAsync(id) > 0;

    public async Task<IEnumerable<ProductDto>> GetProducts(int page, int pageSize)
    {
        var pageParameters = new PageParameters(page, pageSize);

        return await _appContext.Products.Include(p => p.Category).Select(p => (ProductDto)p!)
            .Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize)
            .Take(pageParameters.PageSize).ToListAsync();
    }

    public async Task<IEnumerable<ProductDto>> GetProductsByCategory(int categoryId) 
        => await _appContext.Products.Where(p => p.CategoryId == categoryId).Include(p => p.Category).Select(p => (ProductDto)p!).ToArrayAsync();
    public async Task<IEnumerable<ProductDto>> GetProductsOnSale() 
        => await _appContext.Products.Where(p => p.IsOnSale).Include(p => p.Category).Select(p => (ProductDto)p!).ToArrayAsync();

    public async Task<ProductDto?> GetProductById(int id)
        => await _appContext.Products.FindAsync(id);
    //_appContext.Products.Where(x => x.ProductId == id).Include(p => p.Category).First();

    //IEnumerable<ProductDto> GetProductsByOrderDetailId(int orderDetailId)
    //=> _appContext.Products

}