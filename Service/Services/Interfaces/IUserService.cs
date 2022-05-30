namespace Service.Services.Interfaces;

public interface IUserService
{
    Task<AppUser> GetCurrentUser();
}