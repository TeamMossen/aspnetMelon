namespace aspnetMelon.MinimalApi.EndpointDefinitions;

public class ProductDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/test/", (int personId) =>
        {

            return "test";
        });

     

    }

    public void DefineServices(IServiceCollection services)
    {
        
    }
}