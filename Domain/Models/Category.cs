using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Category
    {
        public int CategoryId { get; set; } = default!;
        public string CategoryName { get; set; } = default!;
        public string CategoryDescription { get; set; } = default!;
        public ICollection<Product>? Products { get; set; }
    }
}
