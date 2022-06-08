using System.Security.Claims;
using Domain.Models.Identity;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace aspnetMelon.MinimalApi.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<AppUser> _userManager;


    public CurrentUserService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
    {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
    }
    public async Task<AppUser> GetCurrentUser() 
        => await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
}