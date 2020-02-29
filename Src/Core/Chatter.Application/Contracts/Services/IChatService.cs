using Chatter.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface IChatService
    {
        Task CreateAsync(Chat chat);
        Task UpdateAsync(Chat chat);
        Task DeleteAsync(int chatId);
        Task<Chat> GetAsync(int chatId);
        Task<IEnumerable<Chat>> GetAsync();
        Task<IEnumerable<Chat>> GetAsync(int pageIndex, int pageSize);
    }
}
