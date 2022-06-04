using aspnetMelon.MinimalApi.Attributes;
using Domain;
using Microsoft.AspNetCore.Authorization;

namespace aspnetMelon.MinimalApi.EndpointDefinitions;

public class ProductEndPoint : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {

        app.MapGet("/test/", [ApiKey] (int personId) =>
            "test");
        app.MapGet("/test/", [ApiKey(Role.Administrator)](int personId) =>
            "test");





    }

    //public void DefineServices(IServiceCollection services)
    //{
        
    //}
}