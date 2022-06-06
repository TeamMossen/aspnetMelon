using Domain.Models.Identity;
using Infrastructure.Services.Interfaces;

namespace aspnetMelon.MinimalApi.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly AppUser _currentUser;
    //private readonly AppDbContext _appContext;

    public CurrentUserService(AppUser currentUser)
    {
        _currentUser = currentUser;
    }
    public async Task<AppUser> GetCurrentUser()
    {
        return await Task.FromResult(_currentUser);
    }
}