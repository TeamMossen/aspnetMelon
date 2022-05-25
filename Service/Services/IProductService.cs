using Service.Models;

namespace Service.Services;

public interface IProductService
{
    IEnumerable<ProductDto> GetProducts(int page, int pageSize);

    IEnumerable<ProductDto> GetProductsOnSale();

    ProductDto GetProductById(int id);
}