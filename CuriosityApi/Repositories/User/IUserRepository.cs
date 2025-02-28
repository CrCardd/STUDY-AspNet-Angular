using CuriosityApi.Entities;

namespace CuriosityApi.Repositories.Product;

public interface IUserRepository
{
    
    Task<ApplicationUser?> FindById(Guid idUser);
    Task<ApplicationUser?> FindByUsername(string username);
    Task<ApplicationUser?> FindByEmail(string email);
    Task<ApplicationUser?> FindByUsernameOrEmail(string _);
    Task<ApplicationUser?> FindByAProductId(Guid idProduct);
}