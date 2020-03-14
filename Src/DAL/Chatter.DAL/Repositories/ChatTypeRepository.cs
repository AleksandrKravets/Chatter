using Chatter.Application.Contracts.Repositories;
using Chatter.DAL.Infrastructure;
using Chatter.DAL.StoredProcedures.ChatTypes;
using Chatter.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.DAL.Repositories
{
    public class ChatTypeRepository : IChatTypeRepository
    {
        private readonly StoredProcedureExecutor _procedureExecutor;

        public ChatTypeRepository(StoredProcedureExecutor procedureExecutor)
        {
            _procedureExecutor = procedureExecutor;
        }

        public Task CreateAsync(ChatType chatType)
        {
            return _procedureExecutor.ExecuteAsync(new CreateChatTypeSP
            {
                Type = chatType.Type
            });
        }

        public Task DeleteAsync(int chatTypeId)
        {
            return _procedureExecutor.ExecuteAsync(new DeleteChatTypeSP 
            { 
                Id = chatTypeId 
            });
        }

        public Task<IEnumerable<ChatType>> GetAllAsync()
        {
            return _procedureExecutor.ExecuteListAsync<ChatType>(new GetChatTypesSP());
        }

        public Task<ChatType> GetAsync(int id)
        {
            return _procedureExecutor.ExecuteOneAsync<ChatType>(new GetChatTypeSP 
            { 
                Id = id 
            });
        }
    }
}
