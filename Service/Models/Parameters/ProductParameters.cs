﻿using Infrastructure.Models.Parameters.Interfaces;

namespace Infrastructure.Models.Parameters;

public class ProductParameters : ISearchParameters
{
    public string SearchTerm { get; set; } = default!;
    public bool IsOnSale { get; set; } = false;
    public bool IsInStock { get; set; } = false;
    public string CategoryName { get; set; } = default!;
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }
}