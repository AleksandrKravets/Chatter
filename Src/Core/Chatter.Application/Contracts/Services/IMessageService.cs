using Chatter.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface IMessageService
    {
        Task<Message> GetAsync(int messageId);
        IEnumerable<Message> Get(int chatId);
        Task CreateAsync(Message message);
        Task UpdateAsync(Message message);
        Task DeleteAsync(int messageId);
        IEnumerable<Message> Get(int chatId, int pageIndex, int pageSize);
    }
}
