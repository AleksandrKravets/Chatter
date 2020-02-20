using Chatter.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface IChatRepository
    {
        Task<Chat> GetAsync(int id); // Guid
        IEnumerable<Chat> Get(); 
        Task CreateAsync(Chat chat);
        Task UpdateAsync(Chat chat);
        Task DeleteAsync(int chatId);
    }
}
