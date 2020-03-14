using Chatter.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface IChatRepository
    {
        Task<Chat> GetAsync(int id);
        Task<IEnumerable<Chat>> GetChatsAsync(int offset, int pageSize);
        Task<Chat> GetChatByNameAsync(string name);
        Task<IEnumerable<Chat>> GetAllAsync();
        Task<int> CreateAsync(Chat chat);
        Task<int> UpdateAsync(Chat chat);
        Task<int> DeleteAsync(int chatId);
    }
}
