using System.Security.Claims;
using Domain.Models;

namespace Service.Services;

public interface IShoppingCartService
{
    //ShoppingCart GetCart(ClaimsPrincipal user);
    void AddToCart(Product product, int amount, ClaimsPrincipal userClaim);
    int RemoveFromCart(Product product);
    List<ShoppingCartItem> GetShoppingCartItems(ClaimsPrincipal user);
    void ClearCart();
    decimal GetShoppingCartTotal();
    void SetShoppingCartItems(IEnumerable<ShoppingCart> shoppingCartItems);
}