using Domain.Models.Identity;

namespace Infrastructure.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly AppDbContext _appContext;

    private readonly ICurrentUserService _userService;

    private readonly AppUser _user;
    //private readonly ISession _session;

    public ShoppingCartService(AppDbContext appContext, ICurrentUserService userService)
    {
        _appContext = appContext;
        _userService = userService;
        _user = _userService.GetCurrentUser().Result;
        //_session = session;
    }

    public ShoppingCart GetCart()
    {

        _user.ShoppingCart.ShoppingCartItems = _appContext.ShoppingCartItems
            .Where(s => s.ShoppingCartId == _user.ShoppingCartId).Include(s => s.Product).ToList();

        return _user.ShoppingCart;
    }
    //   // ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

    //   // string cartId = _session.GetString("CartId") ?? Guid.NewGuid().ToString();
    //   // _session.SetString("CartId", cartId);

    //    return new ShoppingCart() { ShoppingCartId = cartId };
    //}

    public List<ShoppingCartItem> GetShoppingCartItems()
    {
        _user.ShoppingCart.ShoppingCartItems = _appContext.ShoppingCartItems
            .Where(s => s.ShoppingCartId == _user.ShoppingCartId).Include(s => s.Product).ToList();

        return _user.ShoppingCart.ShoppingCartItems!.ToList();

        //_shoppingCart.ShoppingCartItems.ToList();
        //?? (_shoppingCart.ShoppingCartItems = _appContext.ShoppingCartItems.Where
        //                                          (c => c.ShoppingCartId == _shoppingCart.ShoppingCartId).Include
        //                                          (s => s.ProductId));
    }
    public void AddToCart(int productId, int amount)
    {

        var product = _appContext.Products.Find(productId);

        if (product == null) return;

        var shoppingCartItem = _appContext.ShoppingCartItems.SingleOrDefault
            (s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == _user.ShoppingCartId);

        if (shoppingCartItem == null)
        {
            shoppingCartItem = new ShoppingCartItem
            {
                ShoppingCartId = _user.ShoppingCartId,
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

        _appContext.ShoppingCartItems.Where(x => x.ShoppingCartId == _user.ShoppingCartId)
            .DeleteFromQuery();

        _appContext.SaveChanges();
        //_user.ShoppingCart.ShoppingCartItems = new List<ShoppingCartItem>();

        //__userManager.UpdateAsync(_user);
    }



    public decimal GetShoppingCartTotal()
    {

        var total = _appContext.ShoppingCartItems
            .Where(c => c.ShoppingCartId == _user.ShoppingCartId).Select
            (c => c.Product.Price * c.Amount).Sum();

        return total;

    }

    public void SetShoppingCartItems(IEnumerable<ShoppingCartItem> shoppingCartItems)
    {
            
    }

    public void RemoveFromCart(int productId)
    {

        var shoppingCartItem = _appContext.ShoppingCartItems.SingleOrDefault
                     (s => s.ProductId == productId && s.ShoppingCartId == _user.ShoppingCartId);
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
