namespace aspnetMelon.ViewModels;

public class ProductsViewModel
{
    public IEnumerable<ProductDto> Products { get; set; } = default!;

    public string CurrentCategory { get; set; } = "All Products";
}