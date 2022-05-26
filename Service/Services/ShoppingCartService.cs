using Domain;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly AppDbContext _appContext;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartService(AppDbContext appContext, ShoppingCart shoppingCart)
        {
            _appContext = appContext;
            _shoppingCart = shoppingCart;
        }
        public static ShoppingCart StaticGetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart() { ShoppingCartId = cartId };
        }

        public void AddToCart(Product product, int amount)
        {
            var shoppingCartItem = _appContext.ShoppingCartItems.SingleOrDefault
                                 (s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCart.ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Candy = candy,
                    Amount = amount,
                };

                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            _appDbContext.SaveChanges();
        }

        public void ClearCart()
        {
            throw new NotImplementedException();
        }

        public ShoppingCart GetCart(IServiceProvider services)
        {
            return StaticGetCart(services);
        }

        public ICollection<ShoppingCartItem> GetShoppingCartItems()
        {
            return _shoppingCart.ShoppingCartItems ?? (_shoppingCart.ShoppingCartItems = _appContext.ShoppingCartItems.Where
                                                             (c => c.ShoppingCartId == _shoppingCart.ShoppingCartId).Include
                                                             (s => s.ProductId).ToList());
        }

        public decimal GetShoppingCartTotal()
        {
            throw new NotImplementedException();
        }

        public int RemoveFromCart(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
