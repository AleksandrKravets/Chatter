using Chatter.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface IMessageService
    {
        Task CreateAsync(Message message);
        Task UpdateAsync(Message message);
        Task DeleteAsync(int messageId);
        Task<Message> GetAsync(int messageId);
        Task<IEnumerable<Message>> GetAllAsync(int chatId);
        Task<IEnumerable<Message>> GetAsync(int chatId, int pageIndex, int pageSize);
    }
}
