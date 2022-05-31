namespace Service.Services.Interfaces;

public interface IOrderService
{
    public void CreateOrder(OrderDto order);
    public IEnumerable<OrderDto> GetAllOrders();
    public OrderDto? GetOrder(int orderId);
}