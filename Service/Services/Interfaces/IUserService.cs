using Domain.Models;

namespace Service.Services.Interfaces;

public interface IUserService
{
    Task<AppUser> GetCurrentUser();
}