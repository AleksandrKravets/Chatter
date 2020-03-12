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

        public Task CreateAsync(Chat chat)
        {
            return _procedureExecutor.ExecuteAsync(new AddChatSP
            {
                Name = chat.Name
            });
        }

        public Task DeleteAsync(int chatId)
        {
            return _procedureExecutor.ExecuteAsync(new DeleteChatSP
            {
                Id = chatId
            });
        }

        public  Task<IEnumerable<Chat>> GetAllAsync()
        {
            return _procedureExecutor.ExecuteListAsync<Chat>(new GetChatsSP());
        }

        public Task<Chat> GetAsync(int id)
        {
            return _procedureExecutor.ExecuteOneAsync<Chat>(new GetChatByIdSP 
            { 
                ChatId = id 
            });
        }

        public Task UpdateAsync(Chat chat)
        {
            return _procedureExecutor.ExecuteAsync(new UpdateChatSP
            {
                Id = chat.Id,
                Name = chat.Name
            });
        }
    }
}
