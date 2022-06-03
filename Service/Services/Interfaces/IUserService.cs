namespace Infrastructure.Services.Interfaces;

public interface IUserService
{
    Task<AppUser> GetCurrentUser();
}