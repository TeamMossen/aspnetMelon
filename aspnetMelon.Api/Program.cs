using aspnetMelon.MinimalApi;
using aspnetMelon.MinimalApi.EndpointDefinitions;
using aspnetMelon.MinimalApi.Middleware;
using aspnetMelon.MinimalApi.Services;
using Domain;
using Domain.Models.Identity;
using Infrastructure.Services.Interfaces;
using Microsoft.OpenApi.Models;
using static aspnetMelon.MinimalApi.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDomainServices(builder.Configuration);
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();

//builder.Services.AddScoped<AppUser>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddInfrastructureServices(builder.Configuration);

//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpointsMetadataProviderApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition(APIKEYNAME, new OpenApiSecurityScheme()
    {
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Name = APIKEYNAME,
        Description = "Authorization by API-KEY inside request's header",
        Scheme = "ApiKeyScheme"
    });
    var key = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = APIKEYNAME
        },
        In = ParameterLocation.Header
    };
    var requirement = new OpenApiSecurityRequirement
    {
        { key, new List<string>() }
    };
    c.AddSecurityRequirement(requirement);
});

builder.Services.AddEndpointDefinitions(typeof(Program));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();
app.UseEndpointDefinitions();

app.UseMiddleware<AuthMiddleware>();
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();



namespace aspnetMelon.MinimalApi
{
    public static class Constants
    {
        public const string APIKEYNAME = "API-KEY";
    }
    internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}