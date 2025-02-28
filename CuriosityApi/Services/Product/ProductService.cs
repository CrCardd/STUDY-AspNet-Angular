using CuriosityApi.Entities;
using CuriosityApi.Models;
using CuriosityApi.Repositories.Product;
using CuriosityApi.Services.User;
using Microsoft.EntityFrameworkCore;

namespace CuriosityApi.Services.Product;

public class ProductService
(
    IUserRepository userRepository,
    CuriosityDbContext ctx
)
: IProductService
{
    public async Task<ProductModel?> Create(ProductModel data, Guid idUser)
    {
        var user = await userRepository.FindById(idUser);
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

        return new ProductModel(newProduct.Name, newProduct.Description, newProduct.Price);
    }

    public async Task<ProductModel?> GetById(Guid idProduct)
    {
        var query = 
            from p in ctx.Products
            where p.Id == idProduct
            select p;

        var product = await query.FirstOrDefaultAsync();
        if(product is null)
            return null;

        return new ProductModel(product.Name, product.Description, product.Price);
    }

    public async Task<ProductModel?> GetByName(string name)
    {
        var query = 
            from p in ctx.Products
            where p.Name == name
            select p;

        var product = await query.FirstOrDefaultAsync();
        if(product is null)
            return null;

        return new ProductModel(product.Name, product.Description, product.Price);
    }

    public async Task<ProductModel?> GetByUserId(Guid idUser)
    {
        var query = 
            from p in ctx.Products
            where p.OwnerId == idUser
            select p;

        var product = await query.FirstOrDefaultAsync();
        if(product is null)
            return null;

        return new ProductModel(product.Name, product.Description, product.Price);
    }

    public async Task<UserModel?> GetOwner(Guid idProduct)
    {
        
        var query = 
            from p in ctx.Products
            where p.Id == idProduct
            select p.Owner;

        var user = await query.FirstOrDefaultAsync();
        if(user is null)
            return null;

        return new UserModel( user.Id, user.Username);
    }

    public Task<ApplicationProduct?> GetAll()
    {
        throw new NotImplementedException();
        // return ctx.Products;
    }


}