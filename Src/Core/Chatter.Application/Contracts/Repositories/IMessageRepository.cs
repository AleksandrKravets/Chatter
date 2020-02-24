using Chatter.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface IMessageRepository
    {
        Task<Message> GetAsync(int id); // Guid
        IQueryable<Message> Get(int chatId);
        Task CreateAsync(Message message);
        Task UpdateAsync(Message message);
        Task DeleteAsync(int messageId);
    }
}
