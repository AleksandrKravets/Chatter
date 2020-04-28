using Chatter.Application.DataTransferObjects.Chats;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface IChatRepository
    {
        Task<ChatModel> GetChatByNameAsync(string name);
        Task<int> CreateAsync(CreateChatModel chat);
        Task<int> UpdateAsync(long id, UpdateChatModel chat);
        Task<int> DeleteAsync(long chatId);
        Task<ChatModel> GetAsync(long chatId);
        Task<ICollection<ChatModel>> GetAsync();
    }
}
