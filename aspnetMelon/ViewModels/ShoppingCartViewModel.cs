using Domain.Models;

namespace aspnetMelon.ViewModels;

internal class ShoppingCartViewModel
{
    public ShoppingCart ShoppingCart { get; set; } = default!;
    public decimal ShoppingCartTotal { get; set; }
}