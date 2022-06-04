using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace aspnetMelon.MinimalApi.Attributes;

public enum Role { User, Administrator }


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ApiKeyAttribute : Attribute
{
    public ApiKeyAttribute()
    {
        Role = Role.User;
    }
    public ApiKeyAttribute(Role role)
    {
        Role = role;
    }

    public Role Role { get; set; }

    //private const string APIKEYNAME = "ApiKey";
    //public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    //{
    //    if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
    //    {
    //        context.Result = new ContentResult()
    //        {
    //            StatusCode = 401,
    //            Content = "Api Key was not provided"
    //        };
    //        return;
    //    }

    //    // var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

    //    var apiKey = "dasfrweghretghetr";//appSettings.GetValue<string>(APIKEYNAME);

    //    if (!apiKey.Equals(extractedApiKey))
    //    {
    //        context.Result = new ContentResult()
    //        {
    //            StatusCode = 401,
    //            Content = "Api Key is not valid"
    //        };
    //        return;
    //    }

    //    await next();
    //}
}