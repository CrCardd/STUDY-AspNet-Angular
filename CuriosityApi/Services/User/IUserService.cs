using CuriosityApi.Entities;
using CuriosityApi.Models;

namespace CuriosityApi.Services.User;
public interface IUserService
{
    Task<UserModel?> GetUserByEmail(string query);
    Task<UserModel?> GetUserByUsername(string query);
    Task<UserModel?> GetUserByNameOrEmail(string query);  
    Task<UserModel?> GetById(Guid id);  
}