using Infrastructure.Models;

namespace aspnetMelon.ViewModels;

public class HomeViewModel
{
    public IEnumerable<ProductDto> ProductsOnSale { get; set; }
}