namespace Infrastructure.Builders.Interfaces;

public interface ISearchBuilder
{
    public SearchBuilder SetSearchStream(string searchTerm);
    public SearchBuilder SetIsOnSale(bool onSale);
    public SearchBuilder SetIsInStock(bool inStock);
    public SearchBuilder SetCategory(string categoryName);
    public SearchBuilder SetMinPrice(decimal minPrice);
    public SearchBuilder SetMaxPrice(decimal maxPrice);
}