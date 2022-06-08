namespace Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly IShoppingCartService _shoppingCartService;
    private readonly AppDbContext _appContext;

    public OrderService(IShoppingCartService shoppingCartService, AppDbContext appContext)
    {
        _shoppingCartService = shoppingCartService;
        _appContext = appContext;
    }

    public void CreateOrder(OrderDto order)
    {
        List<OrderDetailDto> orderDetails = new List<OrderDetailDto>();
        foreach (var shoppingCartItem in _shoppingCartService.GetShoppingCartItems())
        {
            var orderDetail = new OrderDetail(order.OrderId, shoppingCartItem.Product.ProductId, shoppingCartItem.Amount, shoppingCartItem.Product.Price);
            orderDetails.Add(orderDetail);
        }
        var newOrder = (Order)(order with { OrderPlaced = DateTime.Now, OrderTotal = _shoppingCartService.GetShoppingCartTotal(), OrderDetails = orderDetails });
        _appContext.Orders.Add(newOrder);
        _appContext.SaveChanges();
    }

    public IEnumerable<OrderDto> GetAllOrders()
        => _appContext.Orders.OrderByDescending(o => o.OrderPlaced).Select(o => (OrderDto)o);

    public OrderDto? GetOrder(int orderId) 
        => _appContext.Orders
                .Where(o => o.OrderId == orderId)
                .Include(o => o.OrderDetails)!
                .ThenInclude(o => o.Product)
                .Select(o => (OrderDto)o)
                .FirstOrDefault();
    }