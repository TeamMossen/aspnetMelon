using Infrastructure.Models.Dtos;

namespace aspnetMelon.ViewModels;

public class HomeViewModel
{
    public IEnumerable<ProductDto> ProductsOnSale { get; set; }
}