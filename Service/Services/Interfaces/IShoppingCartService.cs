namespace Infrastructure.Services.Interfaces;

public interface IShoppingCartService
{
    ShoppingCart GetCart();
    void AddToCart(int productId, int amount);
    void RemoveFromCart(int productId);
    List<ShoppingCartItem> GetShoppingCartItems();
    void ClearCart();
    decimal GetShoppingCartTotal();
    void SetShoppingCartItems(IEnumerable<ShoppingCartItem> shoppingCartItems);
}