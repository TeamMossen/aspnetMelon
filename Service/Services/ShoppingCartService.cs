using Domain;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Service.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly AppDbContext _appContext;
    //private readonly ISession _session;
    private readonly UserManager<AppUser> _userManager;

    public ShoppingCartService(AppDbContext appContext, UserManager<AppUser> userManager)
    {
        _appContext = appContext;
        //_session = session;
        _userManager = userManager;
    }

    public ShoppingCart GetCart(ClaimsPrincipal userClaim /*IServiceProvider services*/)
    {
        var user = _userManager.GetUserAsync(userClaim).GetAwaiter().GetResult();
        
        return user.ShoppingCart;
    }
    //   // ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

    //   // string cartId = _session.GetString("CartId") ?? Guid.NewGuid().ToString();
    //   // _session.SetString("CartId", cartId);

    //    return new ShoppingCart() { ShoppingCartId = cartId };
    //}

    public List<ShoppingCartItem> GetShoppingCartItems(ClaimsPrincipal userClaim)
    {

        var user = _userManager.GetUserAsync(userClaim).GetAwaiter().GetResult();

        return user.ShoppingCart.ShoppingCartItems!.ToList();

        //_shoppingCart.ShoppingCartItems.ToList();
        //?? (_shoppingCart.ShoppingCartItems = _appContext.ShoppingCartItems.Where
        //                                          (c => c.ShoppingCartId == _shoppingCart.ShoppingCartId).Include
        //                                          (s => s.ProductId));
    }
    public void AddToCart(int productId, int amount, ClaimsPrincipal userClaim)
    {
        var user = _userManager.GetUserAsync(userClaim).GetAwaiter().GetResult();

        var product = _appContext.Products.Find(productId);

        if (product == null) return;

        var shoppingCartItem = _appContext.ShoppingCartItems.SingleOrDefault
            (s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == user.ShoppingCartId);

        if (shoppingCartItem == null)
        {
            shoppingCartItem = new ShoppingCartItem
            {
                ShoppingCartId = user.ShoppingCartId,
                Product = product,
                Amount = amount,
            };

            _appContext.ShoppingCartItems.Add(shoppingCartItem);
        }
        else
        {
            shoppingCartItem.Amount++;
        }

        _appContext.SaveChanges();
    }

    public void ClearCart(ClaimsPrincipal userClaim)
    {
        var user = _userManager.GetUserAsync(userClaim).GetAwaiter().GetResult();

        user.ShoppingCart.ShoppingCartItems = new List<ShoppingCartItem>();

        _userManager.UpdateAsync(user);
    }



    public decimal GetShoppingCartTotal()
    {
        throw new NotImplementedException();
    }

    public void SetShoppingCartItems(IEnumerable<ShoppingCartItem> shoppingCartItems)
    {
            
    }

    public void RemoveFromCart(ClaimsPrincipal userClaim, int productId)
    {
        var user = _userManager.GetUserAsync(userClaim).GetAwaiter().GetResult();
        var shoppingCartItem = _appContext.ShoppingCartItems.SingleOrDefault
                     (s => s.ProductId == productId && s.ShoppingCartId == user.ShoppingCartId);
        if (shoppingCartItem is not null)
        {
            if (shoppingCartItem.Amount > 1)
                shoppingCartItem.Amount--;
            else
            {
                _appContext.ShoppingCartItems.Remove(shoppingCartItem);
            }
        }
        _appContext.SaveChanges();
    }
}