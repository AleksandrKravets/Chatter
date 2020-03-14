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
            return _procedureExecutor.ExecuteAsync(new CreateChatSP
            {
                Name = chat.Name, 
                /*ChatTypeId = chat.ChatTypeId,*/
                ChatType = (int)chat.ChatType,
                CreatorId = chat.CreatorId
            });
        }

        public Task<int> DeleteAsync(int chatId)
        {
            return _procedureExecutor.ExecuteAsync(new DeleteChatSP
            {
                Id = chatId
            });
        }

        public Task<IEnumerable<Chat>> GetAllAsync()
        {
            return _procedureExecutor.ExecuteListAsync<Chat>(new GetChatsSP());
        }

        public Task<Chat> GetAsync(int id)
        {
            return _procedureExecutor.ExecuteOneAsync<Chat>(new GetChatSP 
            { 
                Id = id 
            });
        }

        public Task<Chat> GetChatByNameAsync(string name)
        {
            return _procedureExecutor.ExecuteOneAsync<Chat>(new GetChatByNameSP 
            { 
                Name = name 
            });
        }

        public Task<IEnumerable<Chat>> GetChatsAsync(int offset, int pageSize)
        {
            return _procedureExecutor.ExecuteListAsync<Chat>(new GetPagingChatsSP 
            { 
                Offset = offset, 
                PageSize = pageSize 
            });
        }

        public Task<int> UpdateAsync(Chat chat)
        {
            return _procedureExecutor.ExecuteAsync(new UpdateChatSP
            {
                Id = chat.Id,
                Name = chat.Name, 
                /*ChatTypeId = chat.ChatTypeId*/
                ChatType = (int)chat.ChatType
            });
        }
    }
}
