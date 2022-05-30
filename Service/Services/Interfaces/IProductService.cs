using Service.Models;

namespace Service.Services.Interfaces;

public interface IProductService
{
    IEnumerable<ProductDto> GetProducts(int page, int pageSize);

    IEnumerable<ProductDto> GetProductsByCategory(int categoryId);

    IEnumerable<ProductDto> GetProductsOnSale();

    ProductDto? GetProductById(int id);
    //IEnumerable<ProductDto> GetProductsByOrderDetailId(int orderDetailId);

}