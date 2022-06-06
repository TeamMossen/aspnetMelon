using Infrastructure.Builders.Interfaces;
using Infrastructure.Parameters;
using LinqKit;
using System.Linq.Expressions;

namespace Infrastructure.Builders;

public class SearchBuilder : ISearchBuilder
{
    private readonly ISearchParameters _searchParameters;
    public SearchBuilder() : this(new SearchParameters()) { }
    public SearchBuilder(ISearchParameters searchParameters)
    {
        _searchParameters = searchParameters;
    }
    public SearchBuilder SetSearchStream(string searchTerm)
    {
        _searchParameters.SearchTerm = searchTerm;
        return this;
    }

    public SearchBuilder SetIsOnSale(bool onSale)
    {
        _searchParameters.IsOnSale = onSale;
        return this;
    }
    public SearchBuilder SetIsInStock(bool inStock)
    {
        _searchParameters.IsInStock = inStock;
        return this;
    }
    public SearchBuilder SetCategory(string categoryName)
    {
        _searchParameters.CategoryName = categoryName;
        return this;
    }
    public SearchBuilder SetMinPrice(decimal minPrice)
    {
        _searchParameters.MinPrice = minPrice;
        return this;
    }
    public SearchBuilder SetMaxPrice(decimal maxPrice)
    {
        _searchParameters.MaxPrice = maxPrice;
        return this;
    }
    public Expression<Func<Product, bool>> Build()
    {
        var predicate = PredicateBuilder.New<Product>(true);
        // Search Term
        if (!string.IsNullOrEmpty(_searchParameters.SearchTerm))
        {
            predicate = predicate.And(
                e => e.Name.Contains(_searchParameters.SearchTerm));
        }
        // Price
        if (_searchParameters.MaxPrice > 0 && _searchParameters.MinPrice > 0)
        {
            predicate = predicate.And(
                e => e.Price >= _searchParameters.MinPrice
                     && e.Price <= _searchParameters.MaxPrice);
        }
        // In Stock
        if (_searchParameters.IsInStock)
        {
            predicate = predicate.And(
                e => e.Stock > 0);
        }
        // On Sale
        if (_searchParameters.IsOnSale)
        {
            predicate = predicate.And(
                e => e.IsOnSale);
        }
        return predicate;
    }
}