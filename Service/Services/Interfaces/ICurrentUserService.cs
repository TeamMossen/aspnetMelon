using Domain.Models.Identity;

namespace Infrastructure.Services.Interfaces;

public interface ICurrentUserService
{
    Task<AppUser> GetCurrentUser();
}