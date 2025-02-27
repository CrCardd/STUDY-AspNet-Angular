using CuriosityApi.Entities;
using CuriosityApi.Services.Password;
using CuriosityApi.Services.Token;
using CuriosityApi.Services.User;
using Microsoft.AspNetCore.Identity;

namespace CuriosityApi.Services.Auth;

public class AuthService
(
    CuriosityDbContext ctx, 
    IPasswordService hasher,
    IUserService userService
) : IAuthService
{
    public async Task<ApplicationUser?> CreateUser(AccountModel data)
    {
        if(userService.FindUserByEmail(data.Email) is not null)
            return null;

        var user = new ApplicationUser {
            Email = data.Email,
            Username = data.Username,
            Password = hasher.Hash(data.Password)
        };

        ctx.Add(user);
        await ctx.SaveChangesAsync();
        return user;
    }

    public async Task<ApplicationUser?> Authenticate(LoginModel data)
    {   
        var user = await userService.FindUserByNameOrEmail(data.Login);
        if( user is null)
            return null;
        
        if(!hasher.Compare(data.Password, user.Password))
            return null;
        
        return user;
    }
}