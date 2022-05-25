﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public int Amount { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public Order Order { get; set; } = default!;

    }
}