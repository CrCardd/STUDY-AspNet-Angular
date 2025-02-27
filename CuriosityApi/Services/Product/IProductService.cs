using CuriosityApi.Entities;
using CuriosityApi.Models;

namespace CuriosityApi.Services.Product;

public interface IProductService {
    Task<ApplicationProduct?> Create(ProductModel data, Guid idUser);
    Task<ApplicationProduct?> FindById(Guid idProduct);
    Task<ApplicationProduct?> FindByName(string query);
    Task<ApplicationProduct?> FindByUserId(Guid idUser);
    Task<ApplicationProduct?> GetAll();
}