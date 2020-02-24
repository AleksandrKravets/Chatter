using Chatter.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface IChatService
    {
        Task<Chat> GetAsync(int chatId);
        IEnumerable<Chat> Get();
        Task CreateAsync(Chat chat);
        Task UpdateAsync(Chat chat);
        Task DeleteAsync(int chatId);
        IEnumerable<Chat> Get(int pageIndex, int pageSize);
    }
}
