namespace Infrastructure.Builders.Interfaces;

public interface IProductSearchBuilder
{
    public ProductSearchBuilder SetSearchStream(string searchTerm);
    public ProductSearchBuilder SetIsOnSale(bool onSale);
    public ProductSearchBuilder SetIsInStock(bool inStock);
    public ProductSearchBuilder SetCategory(string categoryName);
    public ProductSearchBuilder SetMinPrice(decimal minPrice);
    public ProductSearchBuilder SetMaxPrice(decimal maxPrice);
}