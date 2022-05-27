using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;

public class ShoppingCart
{

    public int ShoppingCartId { get; set; }

   // public int AppUserId { get; set; }
    public ICollection<ShoppingCartItem>? ShoppingCartItems { get; set; }
}