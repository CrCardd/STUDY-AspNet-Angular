using CuriosityApi.Entities;
using CuriosityApi.Models;
using CuriosityApi.Services.Product;
using CuriosityApi.Services.User;

namespace CuriosityApi.Services.Cart;

public class CartService 
(
    CuriosityDbContext ctx,
    IUserService userService,
    IProductService productService
)
: ICartService
{
    public async Task<ApplicationCart?> AddProduct(Guid idProduct, Guid idUser)
    {
        var id = idUser;
        var user = await userService.FindById(idUser);
        if(user is null)
            return null;
        var cart = 
            from c in user.Carts
            where c.Activate == true
            select c;
        var foundedCart = cart.FirstOrDefault();
        if(foundedCart is null)
        {
            foundedCart = await CreateCart(idUser);
            if(foundedCart is null)
                return null;
        }
        var product = await productService.FindById(idProduct);
        if(product is null)
            return null;
        foundedCart.Products.Add(product);
        ctx.Update(foundedCart);
        await ctx.SaveChangesAsync();
        return foundedCart;
    }

    public async Task<ApplicationCart?> CreateCart(Guid idUser)
    {
        var user = await userService.FindById(idUser);
        if(user is null)
            return null;
        var cart = new ApplicationCart {
            IdUser = idUser,
            User = user
        };
        ctx.Add(cart);
        await ctx.SaveChangesAsync();
        return cart;
    }

    public async Task<ApplicationCart?> FinishCart(Guid idUser)
    {
        var user = await userService.FindById(idUser);
        var cart =
            from c in user?.Carts
            where c.Activate == true
            select c;
        var foundedCart = cart.FirstOrDefault();
        if(foundedCart is null)
            return null;
        foundedCart.Activate = false;
        ctx.Update(foundedCart);
        await ctx.SaveChangesAsync();
        return foundedCart;
    }
}