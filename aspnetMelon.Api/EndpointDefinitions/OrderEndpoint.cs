using System.Net;
using aspnetMelon.MinimalApi.Attributes;
using Domain.Migrations;
using Microsoft.AspNetCore.Http.HttpResults;

namespace aspnetMelon.MinimalApi.EndpointDefinitions;

public class OrderEndpoint : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        // GET ALL ORDERS
        app.MapGet("/orders", [ApiKey(Role.Administrator)] async (IOrderService orderService) =>
        {
            var orders = orderService.GetAllOrders();
            return orders;
        });
        // GET ORDER BY ID
        app.MapGet("/orders/{id}", [ApiKey(Role.Administrator)] async (IOrderService orderService, int id) =>
        {
            var order = orderService.GetOrder(id);
            return order != null ? Results.Ok(order) : Results.NotFound();
        });
    }
}