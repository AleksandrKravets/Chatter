using Chatter.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface IMessageRepository
    {
        Task<Message> GetAsync(int id);
        Task<IEnumerable<Message>> GetAllAsync(int chatId);
        Task CreateAsync(Message message);
        Task UpdateAsync(Message message);
        Task DeleteAsync(int messageId);
    }
}
