namespace Domain.Models;

public class OrderDetail
{
    public OrderDetail(int orderId, int productId, int amount, decimal price)
    {
        OrderId = orderId;
        ProductId = productId;
        Amount = amount;
        Price = price;
    }

    public int OrderDetailId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; } = default!;
    public int Amount { get; set; } = default!;
    public decimal Price { get; set; } = default!;
    public Order Order { get; set; } = default!;

}