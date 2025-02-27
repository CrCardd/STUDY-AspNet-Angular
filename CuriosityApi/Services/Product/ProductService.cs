using CuriosityApi.Entities;
using CuriosityApi.Models;
using CuriosityApi.Services.User;
using Microsoft.EntityFrameworkCore;

namespace CuriosityApi.Services.Product;

public class ProductService
(
    IUserService userService,
    CuriosityDbContext ctx
)
: IProductService
{
    public async Task<ApplicationProduct?> Create(ProductModel data, Guid idUser)
    {
        var user = await userService.FindById(idUser);
        if(user is null)
            return null;
         var newProduct = new ApplicationProduct {
            Name = data.Name,
            Price = data.Price,
            Description = data.Description,
            OwnerId = idUser,
            Owner = user
        };
        ctx.Add(newProduct);
        await ctx.SaveChangesAsync();
        return newProduct;
    }

    public Task<ApplicationProduct?> FindById(Guid idProduct)
    {
        var product = 
            from p in ctx.Products
            where p.Id == idProduct
            select p;
        return product.FirstOrDefaultAsync();
    }

    public Task<ApplicationProduct?> FindByName(string query)
    {
        var product = 
            from p in ctx.Products
            where p.Name == query
            select p;
        return product.FirstOrDefaultAsync();
    }

    public Task<ApplicationProduct?> FindByUserId(Guid idUser)
    {
        
        var product = 
            from p in ctx.Products
            where p.OwnerId == idUser
            select p;
        return product.FirstOrDefaultAsync();
    }

    public Task<ApplicationProduct?> GetAll()
    {
        return ctx.Products;
    }
}