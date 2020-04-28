using Chatter.Application.DataTransferObjects.Chats;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface IChatService
    {
        Task CreateAsync(CreateChatModel chat);
        Task UpdateAsync(long id, UpdateChatModel chat);
        Task DeleteAsync(long chatId);
        Task<ChatModel> GetAsync(long chatId);
        Task<ICollection<ChatModel>> GetAsync();
        Task JoinChatAsync(long chatId, long userId);
        Task LeaveChatAsync(long chatId, long userId);
    }
}
