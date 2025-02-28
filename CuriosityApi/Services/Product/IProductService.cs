using CuriosityApi.Entities;
using CuriosityApi.Models;

namespace CuriosityApi.Services.Product;

public interface IProductService {
    Task<ProductModel?> Create(ProductModel data, Guid idUser);
    Task<ProductModel?> GetById(Guid idProduct);
    Task<ProductModel?> GetByName(string query);
    Task<ProductModel?> GetByUserId(Guid idUser);
    Task<ApplicationProduct?> GetAll();
    Task<UserModel?> GetOwner(Guid idProduct);
    
}