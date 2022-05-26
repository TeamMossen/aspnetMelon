using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models;

public record OrderDetailDto(int OrderDetailId, int OrderId, int ProductId, int Amount, decimal Price)
{
    public static implicit operator OrderDetailDto(OrderDetail orderDetail) =>
        new(orderDetail.OrderDetailId, orderDetail.OrderId, orderDetail.ProductId, orderDetail.Amount, orderDetail.Price);
}