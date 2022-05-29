using Domain.Models;

namespace Service.Services;

public class OrderService : IOrderService
{
    public void CreateOrder(OrderDto order)
    {
        var hej = new Order(order);


        order.OrderPlaced = DateTime.Now;
        order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
        _appDbContext.Orders.Add(order);
        _appDbContext.SaveChanges();

        var shoppingCartItems = _shoppingCart.GetShoppingCartItems();

        foreach (var shoppingCartItem in shoppingCartItems)
        {
            var orderDetail = new OrderDetail
            {
                Amount = shoppingCartItem.Amount,
                Price = shoppingCartItem.Candy.Price,
                CandyId = shoppingCartItem.Candy.CandyId,
                OrderId = order.OrderId
            };

            _appDbContext.OrderDetails.Add(orderDetail);
        }
        _appDbContext.SaveChanges();
    }

}