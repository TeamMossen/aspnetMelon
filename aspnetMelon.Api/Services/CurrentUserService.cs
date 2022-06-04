using Domain;
using Domain.Models.Identity;
using Infrastructure.Services.Interfaces;

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
            return await _appContext.Users.FindAsync(1);
        }
    }
}
