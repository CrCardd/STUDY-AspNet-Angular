using CuriosityApi.Entities;

namespace CuriosityApi.Repositories.Product;

public interface IProductRepository
{
    
    Task<ApplicationProduct?> FindById(Guid idProduct);
    Task<ApplicationProduct?> FindByName(string query);
    Task<ApplicationProduct?> FindByUserId(Guid idUser);
}