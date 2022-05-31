namespace Service.Models;

public record OrderDetailDto(int OrderDetailId, int OrderId, int ProductId, int Amount, decimal Price, ProductDto? product = null)
{
    public static implicit operator OrderDetailDto(OrderDetail orderDetail) =>
        new(orderDetail.OrderDetailId, orderDetail.OrderId, orderDetail.ProductId, orderDetail.Amount, orderDetail.Price, orderDetail.Product);

    public static implicit operator OrderDetail(OrderDetailDto orderDetail) =>
    new(orderDetail.OrderId, orderDetail.ProductId, orderDetail.Amount, orderDetail.Price);

}