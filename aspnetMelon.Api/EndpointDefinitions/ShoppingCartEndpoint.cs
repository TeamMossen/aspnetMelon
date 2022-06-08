using aspnetMelon.MinimalApi.Attributes;

namespace aspnetMelon.MinimalApi.EndpointDefinitions;

public class ShoppingCartEndpoint : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/shoppingcart", [ApiKey(Role.User)] async (IShoppingCartService shoppingcartService, ICurrentUserService userService) =>
        {
            var cart = shoppingcartService.GetCart();
            return cart.ShoppingCartItems;
        });
    }
}