using CuriosityApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CuriosityApi.Repositories.Product;

public class UserRepository
(
    CuriosityDbContext ctx
)
: IUserRepository
{
    public async Task<ApplicationUser?> FindByAProductId(Guid idProduct)
    {
        var query = 
            from q in ctx.Products
            where q.Id == idProduct
            select q.Owner;

        return await query.FirstOrDefaultAsync();
    }

    public async Task<ApplicationUser?> FindByEmail(string email)
    {
        var query = 
            from q in ctx.Users
            where q.Email == email
            select q;

        return await query.FirstOrDefaultAsync();
    }

    public async Task<ApplicationUser?> FindById(Guid idUser)
    {
        var query = 
            from q in ctx.Users
            where q.Id == idUser
            select q;

        return await query.FirstOrDefaultAsync();
    }

    public async Task<ApplicationUser?> FindByUsername(string username)
    {
        var query = 
            from q in ctx.Users
            where q.Username == username
            select q;

        return await query.FirstOrDefaultAsync();
    }

    public async Task<ApplicationUser?> FindByUsernameOrEmail(string _)
    {
        var query = 
            from q in ctx.Users
            where q.Username == _ || q.Email == _
            select q;

        return await query.FirstOrDefaultAsync();
    }
}