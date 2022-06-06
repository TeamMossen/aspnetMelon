namespace Infrastructure.Models.Parameters.Interfaces;

public interface ISearchParameters
{
    public string SearchTerm { get; set; }
    bool IsOnSale { get; set; }
    bool IsInStock { get; set; }
    string CategoryName { get; set; }
    decimal MinPrice { get; set; }
    decimal MaxPrice { get; set; }

}