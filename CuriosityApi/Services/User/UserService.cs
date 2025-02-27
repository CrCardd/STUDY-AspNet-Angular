using CuriosityApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CuriosityApi.Services.User;


public class UserService(CuriosityDbContext ctx) : IUserService
{
    public async Task<ApplicationUser?> FindUserByEmail(string query)
    {
        var user = 
            from u in ctx.Users
            where u.Email == query
            select u;

        return await user.FirstOrDefaultAsync();
    }

    public async Task<ApplicationUser?> FindUserByUsername(string query)
    {
        var user = 
            from u in ctx.Users
            where u.Username == query
            select u;

        return await user.FirstOrDefaultAsync();
    }

    public async Task<ApplicationUser?> FindUserByNameOrEmail(string query)
    {
        var user = 
            from u in ctx.Users
            where u.Email == query || u.Username == query
            select u;

        return await user.FirstOrDefaultAsync();
    }

    public Task<ApplicationUser?> FindById(Guid id)
    {
        var user = 
            from u in ctx.Users
            where u.Id == id
            select u;
        return user.FirstOrDefaultAsync();
    }
}
