using CuriosityApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CuriosityApi.Repositories.Product;

public class ProductRepository
(
    CuriosityDbContext ctx
) 
: IProductRepository
{
    public async Task<ApplicationProduct?> FindById(Guid idProduct)
    {
        var query = 
            from p in ctx.Products
            where p.Id == idProduct
            select p;

        return await query.FirstOrDefaultAsync();
    }

    public async Task<ApplicationProduct?> FindByName(string name)
    {
        var query = 
            from p in ctx.Products
            where p.Name == name
            select p;

        return await query.FirstOrDefaultAsync();
    }

    public async Task<ApplicationProduct?> FindByUserId(Guid idUser)
    {
        var query = 
            from p in ctx.Products
            where p.OwnerId == idUser
            select p;

        return await query.FirstOrDefaultAsync();
    }

}