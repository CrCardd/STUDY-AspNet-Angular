using CuriosityApi.Entities;
using CuriosityApi.Models;
using CuriosityApi.Repositories.Product;
using CuriosityApi.Services.Product;
using CuriosityApi.Services.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CuriosityApi.Services.Chat;

public class ChatService
(
    CuriosityDbContext ctx,
    IUserService userService,
    IProductService productService,

    IProductRepository productRepository,
    IUserRepository userRepository
)
: IChatService
{
    public async Task<ApplicationChat?> Create(ChatModel data)
    {
        var chats = 
            from c in ctx.Chats
            where c.UserAId == data.IdUserA || c.UserBId == data.IdUserB &&
                  c.UserAId == data.IdUserB || c.UserBId == data.IdUserA
            select c;
        
        if(chats.Any())
            return null;
        
        var userA = await userRepository.FindById(data.IdUserA);
        var userB = await userRepository.FindById(data.IdUserB);
        var product = await productRepository.FindById(data.IdProduct);
        if(userA is null || userB is null || product is null)
            return null;
        
        var chat = new ApplicationChat {
            UserA = userA,
            UserAId = data.IdUserA,
            UserB = userB,
            UserBId = data.IdUserB,
            IdProduct = data.IdProduct,
            Product = product
        };

        ctx.Add(chat);
        await ctx.SaveChangesAsync();
        return chat;
    }

    public async Task<ObjectListModel<UserChatModel>?> GetUserChats(Guid idUser)
    {
        var chatsQuery =
            from c in ctx.Chats
            where c.Id == idUser
            select c;
        var chats = await chatsQuery.ToListAsync();

        List<UserChatModel> userChats = [];
        foreach(var chat in chats)
        {
            var userA = await userService.GetById(chat.UserAId);
            var userB = await userService.GetById(chat.UserBId);
            var product = await productService.GetById(chat.IdProduct);

            if(userA is null || userB is null || product is null)
                return null;
            
            userChats.Add(
                new UserChatModel
                ( 
                    new UserModel
                    (
                        userA.Id,
                        userA.Username
                    ),
                    new UserModel
                    (
                        userB.Id,
                        userB.Username
                    ),
                    new ProductModel
                    (
                        product.Name,
                        product.Description,
                        product.Price
                    )
                )
            );
        }

        return new(userChats, userChats.Count);
    }
}