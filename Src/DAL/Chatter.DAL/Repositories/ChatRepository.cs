using Chatter.Application.Contracts.Repositories;
using Chatter.DAL.Infrastructure;
using Chatter.DAL.StoredProcedures.Chats;
using Chatter.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.DAL.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly StoredProcedureExecutor _procedureExecutor;

        public ChatRepository(StoredProcedureExecutor procedureExecutor)
        {
            _procedureExecutor = procedureExecutor;
        }

        public Task<int> CreateAsync(Chat chat)
        {
        }

        public Task<int> DeleteAsync(int chatId)
        {
        }

        public Task<IEnumerable<Chat>> GetAllAsync()
        {
        }

        public Task<Chat> GetAsync(int id)
        {
        }

        public Task<Chat> GetChatByNameAsync(string name)
        {
        }

        public Task<IEnumerable<Chat>> GetChatsAsync(int offset, int pageSize)
        {
        }

        public Task<int> UpdateAsync(Chat chat)
        {
        }
    }
}
