using aspnetMelon.MinimalApi.Attributes;
using Domain;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;

namespace aspnetMelon.MinimalApi.Middleware;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext httpContext, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        var endpoint = httpContext.Features.Get<IEndpointFeature>()?.Endpoint;
        var attribute = endpoint?.Metadata.GetMetadata<ApiKeyAttribute>();

        if (attribute is null)
        {
            await _next(httpContext);
            return;
        }


        if (!httpContext.Request.Headers.TryGetValue(Constants.APIKEYNAME, out var extractedApiKey))
        {
            httpContext.Response.StatusCode = 401;
            await httpContext.Response.WriteAsync("Api Key was not provided.");
            return;
        }

        var user = userManager.Users.FirstOrDefault(u => u.ApiKey == extractedApiKey.FirstOrDefault());

        if (user is null)
        {
            httpContext.Response.StatusCode = 401;
            await httpContext.Response.WriteAsync("Api Key was not valid");
            return;
        }

        httpContext.Items.Add("User", user);
        //await signInManager.SignInAsync(user, false);
        //httpContext.User.AddIdentity(await signInManager.SignInAsync(user, false)); ;
        //var userClaims = await userManager.GetClaimsAsync(user);


        if (attribute is { Role: Role.Administrator } &&
            !userManager.IsInRoleAsync(user, "Administrator").Result)
        {
            httpContext.Response.StatusCode = 401;
            await httpContext.Response.WriteAsync("Only administrators can access this endpoint");
            return;
        }
       
        //API key auth is User
        await _next(httpContext); // calling next middleware

    }

}