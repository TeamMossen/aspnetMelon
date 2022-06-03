using Infrastructure.Models;

namespace Infrastructure.Services.Interfaces;

public interface IProductService
{
    Task<bool> AddOrUpdate(ProductDto product);

    Task<bool> Delete(int id);

    Task<IEnumerable<ProductDto>> GetProducts(int page, int pageSize);

    Task<IEnumerable<ProductDto>> GetProductsByCategory(int categoryId);

    Task<IEnumerable<ProductDto>> GetProductsOnSale();

    Task<ProductDto?> GetProductById(int id);
    //IEnumerable<ProductDto> GetProductsByOrderDetailId(int orderDetailId);

}