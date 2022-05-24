using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public string ShoppingCartId { get; set; } = default!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public int Amount { get; set; }

    }
}
