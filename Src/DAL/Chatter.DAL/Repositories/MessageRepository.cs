using Chatter.Application.Contracts.Repositories;
using Chatter.DAL.Infrastructure;
using Chatter.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.DAL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly StoredProcedureExecutor _procedureExecutor;

        public MessageRepository(StoredProcedureExecutor procedureExecutor)
        {
            _procedureExecutor = procedureExecutor;
        }

        public Task<int> CreateAsync(Message message)
        {
        }

        public Task<int> DeleteAsync(int messageId)
        {
        }

        public Task<IEnumerable<Message>> GetAllAsync(int chatId)
        {
        }

        public Task<Message> GetAsync(int id)
        {
        }

        public Task<IEnumerable<Message>> GetMessagesAsync(int chatId, int offset, int pageSize)
        {
        }

        public Task<int> UpdateAsync(Message message)
        {
        }
    }
}
