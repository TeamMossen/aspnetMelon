﻿using aspnetMelon.MinimalApi.Attributes;
using Domain;
using Domain.Models.Identity;
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
    public async Task Invoke(HttpContext httpContext, AppDbContext appDbContext, UserManager<AppUser> userManager, AppUser currentUser)
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
        currentUser = user;
        //userManager.user
        //var user = await userManager.Users.Where(u => u.ApiKey == extractedApiKey)
        //    .Include(x => x.UserRoles)
        //    .ThenInclude(x => x.Role).AsNoTracking().SingleOrDefaultAsync();


        //var currentRole = await appDbContext.UserRoles.Where(u => u.UserId == currentUser.Id)
        //    .Join(appDbContext.Roles, u => u.).ToListAsync();

        //var currentRole = await appDbContext.UserRoles
        //    .Join(appDbContext.Roles, user => user.RoleId, role => role.Id, (userRole, appRole)
        //        => new
        //        {
        //            userRo
        //        }).ToListAsync();
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