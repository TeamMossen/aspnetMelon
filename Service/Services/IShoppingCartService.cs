using Domain.Models;

namespace Service.Services
{
    public interface IShoppingCartService
    {
        ShoppingCart GetCart(IServiceProvider services);
        void AddToCart(Product product, int amount);
        int RemoveFromCart(Product product);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
    }
}
