using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; } = default!;
        public string ShoppingCartId { get; set; } = default!;
        public Product Product { get; set; } = default!;
        public int Amount { get; set; } = default!;

    }
}
