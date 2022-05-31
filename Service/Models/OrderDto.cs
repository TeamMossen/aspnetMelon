namespace Service.Models;

public record OrderDto(int OrderId, string FirstName, string LastName, string PhoneNumber, string Address, string ZipCode, string City, string State, DateTime OrderPlaced, decimal OrderTotal, ICollection<OrderDetailDto> OrderDetails)
{
    public static implicit operator OrderDto(Order order) =>
        new(order.OrderId, order.FirstName, order.LastName, order.PhoneNumber, order.Address,
            order.ZipCode, order.City, order.State, order.OrderPlaced, order.OrderTotal, order.OrderDetails?.Select(o => (OrderDetailDto)o).ToList()!);

    public static implicit operator Order(OrderDto order) =>
    new(order.OrderId, order.FirstName, order.LastName, order.PhoneNumber, order.Address,
        order.ZipCode, order.City, order.State, order.OrderPlaced, order.OrderTotal, order.OrderDetails.Select(o => (OrderDetail)o).ToList());

}