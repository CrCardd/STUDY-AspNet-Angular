namespace CuriosityApi.Models;

public record ChatModel (
    Guid IdUserA,
    Guid IdUserB,
    Guid IdProduct
);