namespace CuriosityApi.Models;

public record UserChatModel (
    UserModel UserA,
    UserModel UserB,
    ProductModel Product
);