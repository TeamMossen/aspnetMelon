using System.Security.Claims;
using Domain.Models;

namespace Service.Services;

public interface IShoppingCartService
{
    ShoppingCart GetCart(ClaimsPrincipal userClaim);
    void AddToCart(int productId, int amount, ClaimsPrincipal userClaim);
    int RemoveFromCart(Product product);
    List<ShoppingCartItem> GetShoppingCartItems(ClaimsPrincipal userClaim);
    void ClearCart();
    decimal GetShoppingCartTotal();
    void SetShoppingCartItems(IEnumerable<ShoppingCart> shoppingCartItems);
}