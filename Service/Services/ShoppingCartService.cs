using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Service.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly AppDbContext _appContext;

    private readonly IUserService _userService;
    //private readonly ISession _session;
    //private readonly UserManager<AppUser> _userManager;

    public ShoppingCartService(AppDbContext appContext, IUserService userService, UserManager<AppUser> userManager)
    {
        _appContext = appContext;
        _userService = userService;
        //_session = session;
        //_userManager = userManager;
    }

    public ShoppingCart GetCart()
    {
        var user = _userService.GetCurrentUser().Result;

        user.ShoppingCart.ShoppingCartItems = _appContext.ShoppingCartItems
            .Where(s => s.ShoppingCartId == user.ShoppingCartId).Include(s => s.Product).ToList();

        return user.ShoppingCart;
    }
    //   // ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

    //   // string cartId = _session.GetString("CartId") ?? Guid.NewGuid().ToString();
    //   // _session.SetString("CartId", cartId);

    //    return new ShoppingCart() { ShoppingCartId = cartId };
    //}

    public List<ShoppingCartItem> GetShoppingCartItems()
    {

        var user = _userService.GetCurrentUser().Result;
        user.ShoppingCart.ShoppingCartItems = _appContext.ShoppingCartItems
            .Where(s => s.ShoppingCartId == user.ShoppingCartId).Include(s => s.Product).ToList();

        return user.ShoppingCart.ShoppingCartItems!.ToList();

        //_shoppingCart.ShoppingCartItems.ToList();
        //?? (_shoppingCart.ShoppingCartItems = _appContext.ShoppingCartItems.Where
        //                                          (c => c.ShoppingCartId == _shoppingCart.ShoppingCartId).Include
        //                                          (s => s.ProductId));
    }
    public void AddToCart(int productId, int amount)
    {
        var user = _userService.GetCurrentUser().Result;

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

    public void ClearCart()
    {
        var user = _userService.GetCurrentUser().Result;

        _appContext.ShoppingCartItems.Where(x => x.ShoppingCartId == user.ShoppingCartId)
            .DeleteFromQuery();

        _appContext.SaveChanges();
        //user.ShoppingCart.ShoppingCartItems = new List<ShoppingCartItem>();

        //_userManager.UpdateAsync(user);
    }



    public decimal GetShoppingCartTotal()
    {
        var user = _userService.GetCurrentUser().Result;

        var total = _appContext.ShoppingCartItems
            .Where(c => c.ShoppingCartId == user.ShoppingCartId).Select
            (c => c.Product.Price * c.Amount).Sum();

        return total;

    }

    public void SetShoppingCartItems(IEnumerable<ShoppingCartItem> shoppingCartItems)
    {
            
    }

    public void RemoveFromCart(int productId)
    {
        var user = _userService.GetCurrentUser().Result;

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
