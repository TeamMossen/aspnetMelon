using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; } 
        public string ImageUrl { get; set; } = default!;
        public string ImageThumbnailUrl { get; set; } = default!;
        public bool IsOnSale { get; set; } 
        public int Stock { get; set; }
        public int CategoryId { get; set; } 
        public Category Category { get; set; } = default!;

    }
}
