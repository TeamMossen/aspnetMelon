using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Product
    {
        public int ProductId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public string ImageThumbnailUrl { get; set; } = default!;
        public bool IsOnSale { get; set; } = default!;
        public bool IsInStock { get; set; } = default!;
        public int CategoryId { get; set; } = default!;
        public Category Category { get; set; } = default!;

    }
}
