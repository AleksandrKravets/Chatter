using Chatter.Application.DataTransferObjects.Chats;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface IChatRepository
    {
        Task<ChatModel> GetChatByNameAsync(string name);
        Task<int> CreateAsync(CreateChatModel chat);
        Task<int> UpdateAsync(int id, UpdateChatModel chat);
        Task<int> DeleteAsync(int chatId);
        Task<ChatModel> GetAsync(int chatId);
        Task<ICollection<ChatModel>> GetAsync();
        Task<ICollection<ChatModel>> GetAsync(int pageIndex, int pageSize);
    }
}
