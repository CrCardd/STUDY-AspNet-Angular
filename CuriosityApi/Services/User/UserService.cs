using CuriosityApi.Entities;
using CuriosityApi.Models;
using CuriosityApi.Repositories.Product;
using Microsoft.EntityFrameworkCore;

namespace CuriosityApi.Services.User;


public class UserService
(
    IUserRepository userRepository
) 
: IUserService
{
    public async Task<UserModel?> GetUserByEmail(string query)
    {
        var user = await userRepository.FindByEmail(query);
        if(user is null)
            return null;
        return new UserModel(user.Id, user.Username);
    }

    public async Task<UserModel?> GetUserByUsername(string query)
    {
        var user = await userRepository.FindByUsername(query);
        if(user is null)
            return null;
        return new UserModel(user.Id, user.Username);
    }

    public async Task<UserModel?> GetUserByNameOrEmail(string query)
    {
        var user = await userRepository.FindByUsernameOrEmail(query);
        if(user is null)
            return null;
        return new UserModel(user.Id, user.Username);
    }

    public async Task<UserModel?> GetById(Guid id)
    {
        var user = await userRepository.FindById(id);
        if(user is null)
            return null;
        return new UserModel(user.Id, user.Username);
    }
}
