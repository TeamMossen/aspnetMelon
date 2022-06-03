namespace aspnetMelon.MinimalApi.EndpointDefinitions;

public class ProductDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/test/",() => "test");
    }

    public void DefineServices(IServiceCollection services)
    {
        
    }
}