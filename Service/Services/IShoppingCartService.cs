using System.Security.Claims;
using Domain.Models;

namespace Service.Services;

public interface IShoppingCartService
{
    ShoppingCart GetCart(ClaimsPrincipal userClaim);
    void AddToCart(int productId, int amount, ClaimsPrincipal userClaim);
    void RemoveFromCart(ClaimsPrincipal userClaim, int productId);
    List<ShoppingCartItem> GetShoppingCartItems(ClaimsPrincipal userClaim);
    void ClearCart(ClaimsPrincipal userClaim);
    decimal GetShoppingCartTotal(ClaimsPrincipal userClaim);
    void SetShoppingCartItems(IEnumerable<ShoppingCartItem> shoppingCartItems);
}