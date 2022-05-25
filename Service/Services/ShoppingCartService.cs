using Domain;
using Domain.Models;
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

        public ShoppingCartService(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public void AddToCart(Product product, int amount)
        {
            throw new NotImplementedException();
        }

        public void ClearCart()
        {
            throw new NotImplementedException();
        }

        public ShoppingCart GetCart(IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            throw new NotImplementedException();
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
