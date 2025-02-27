using CuriosityApi.Entities;
using CuriosityApi.Models;

namespace CuriosityApi.Services.Cart;

public interface ICartService {
    Task<ApplicationCart?> AddProduct(Guid idProduct, Guid idUser);
    Task<ApplicationCart?> FinishCart(Guid idUser);
    Task<ApplicationCart?> CreateCart(Guid idUser);
}