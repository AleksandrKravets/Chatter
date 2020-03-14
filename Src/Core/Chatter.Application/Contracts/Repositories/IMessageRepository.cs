using Chatter.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface IMessageRepository
    {
        Task<Message> GetAsync(int id);
        Task<IEnumerable<Message>> GetAllAsync(int chatId);
        Task<int> CreateAsync(Message message);
        Task<int> UpdateAsync(Message message);
        Task<int> DeleteAsync(int messageId);
    }
}
