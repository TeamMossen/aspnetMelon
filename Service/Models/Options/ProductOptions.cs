namespace Infrastructure.Models.Options;

public class ProductOptions
{
    public bool IsOnSale { get; set; }
    public bool IsInStock { get; set; }
    public string CategoryName { get; set; }
    public int MinPrice { get; set; }
    public int MaxPrice { get; set; }

}