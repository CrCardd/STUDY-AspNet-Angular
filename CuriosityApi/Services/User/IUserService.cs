using CuriosityApi.Entities;

namespace CuriosityApi.Services.User;
public interface IUserService
{
    Task<ApplicationUser?> FindUserByEmail(string query);
    Task<ApplicationUser?> FindUserByUsername(string query);
    Task<ApplicationUser?> FindUserByNameOrEmail(string query);  
    Task<ApplicationUser?> FindById(Guid id);  
}