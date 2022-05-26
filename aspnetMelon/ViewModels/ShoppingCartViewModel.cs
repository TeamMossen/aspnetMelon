using Domain.Models;

namespace aspnetMelon.ViewModels
{
    public class ShoppingCartViewModel
{
    public ShoppingCart ShoppingCart { get; set; } = default!;
    public decimal ShoppingCartTotal { get; set; }

    }
}