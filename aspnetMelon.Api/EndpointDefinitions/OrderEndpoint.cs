using aspnetMelon.MinimalApi.Attributes;

namespace aspnetMelon.MinimalApi.EndpointDefinitions;

public class OrderEndpoint : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/orders", [ApiKey(Role.Administrator)] async (IOrderService orderService) =>
        {
            var orders = orderService.GetAllOrders();
            return orders;
        });
    }
}