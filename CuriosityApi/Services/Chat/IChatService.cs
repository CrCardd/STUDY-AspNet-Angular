using CuriosityApi.Entities;

namespace CuriosityApi.Services.Chat;

public interface IChatService {
    Task<ApplicationChat> Create(Guid UserA, Guid UserB);
}