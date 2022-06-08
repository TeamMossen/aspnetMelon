using Infrastructure.Builders.Interfaces;
using LinqKit;
using System.Linq.Expressions;
using Infrastructure.Models.Parameters;
using Infrastructure.Models.Parameters.Interfaces;

namespace Infrastructure.Builders;

public class ProductSearchBuilder : IProductSearchBuilder
{
    private readonly ISearchParameters _searchParameters;
    public ProductSearchBuilder() : this(new ProductParameters()) { }
    public ProductSearchBuilder(ISearchParameters searchParameters)
    {
        _searchParameters = searchParameters;
    }
    public ProductSearchBuilder SetSearchStream(string searchTerm)
    {
        _searchParameters.SearchTerm = searchTerm;
        return this;
    }

    public ProductSearchBuilder SetIsOnSale(bool onSale)
    {
        _searchParameters.IsOnSale = onSale;
        return this;
    }
    public ProductSearchBuilder SetIsInStock(bool inStock)
    {
        _searchParameters.IsInStock = inStock;
        return this;
    }
    public ProductSearchBuilder SetCategory(string categoryName)
    {
        _searchParameters.CategoryName = categoryName;
        return this;
    }
    public ProductSearchBuilder SetMinPrice(decimal minPrice)
    {
        _searchParameters.MinPrice = minPrice;
        return this;
    }
    public ProductSearchBuilder SetMaxPrice(decimal maxPrice)
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
                e => e.IsOnSale == _searchParameters.IsOnSale);
        }
        // Category
        if (!string.IsNullOrEmpty(_searchParameters.CategoryName))
        {
            predicate = predicate.And(
                e => e.Category.CategoryName == _searchParameters.CategoryName);
        }
        return predicate;
    }
}