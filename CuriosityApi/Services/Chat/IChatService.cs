using CuriosityApi.Entities;
using CuriosityApi.Models;

namespace CuriosityApi.Services.Chat;

public interface IChatService {
    Task<ApplicationChat?> Create(ChatModel data);
    Task<ObjectListModel<UserChatModel>?> GetUserChats(Guid idUser);

}