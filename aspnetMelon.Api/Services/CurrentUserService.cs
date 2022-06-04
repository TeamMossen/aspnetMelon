using Domain;
using Domain.Models.Identity;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace aspnetMelon.MinimalApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly AppDbContext _appContext;

        public CurrentUserService(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<AppUser> GetCurrentUser()
        {
            return await _appContext.Users.SingleAsync(u => u.ApiKey == "");
        }
    }
}
