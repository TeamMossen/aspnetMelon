using Domain.Models;

namespace Service.Models;

public record OrderDetailDto(int OrderDetailId, int OrderId, int ProductId, int Amount, decimal Price)
{
    public static implicit operator OrderDetailDto(OrderDetail orderDetail) =>
        new(orderDetail.OrderDetailId, orderDetail.OrderId, orderDetail.ProductId, orderDetail.Amount, orderDetail.Price);

    public static implicit operator OrderDetail(OrderDetailDto orderDetail) =>
    new(orderDetail.OrderDetailId, orderDetail.OrderId, orderDetail.ProductId, orderDetail.Amount, orderDetail.Price);

}