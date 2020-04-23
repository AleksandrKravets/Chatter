using Chatter.Application.DataTransferObjects.Chats;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface IChatService
    {
        Task CreateAsync(CreateChatModel chat);
        Task UpdateAsync(int id, UpdateChatModel chat);
        Task DeleteAsync(int chatId);
        Task<ChatModel> GetAsync(int chatId);
        Task<ICollection<ChatModel>> GetAsync();
        Task<ICollection<ChatModel>> GetAsync(int pageIndex, int pageSize);
        Task JoinChatAsync(int chatId, int userId);
        Task LeaveChatAsync(int chatId, int userId);
    }
}
