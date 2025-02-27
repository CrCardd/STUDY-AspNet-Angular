using CuriosityApi.Entities;

namespace CuriosityApi.Services.Auth;

public interface IAuthService
{
    Task<ApplicationUser?> CreateUser(AccountModel data);
    Task<ApplicationUser?> Authenticate(LoginModel data);

}