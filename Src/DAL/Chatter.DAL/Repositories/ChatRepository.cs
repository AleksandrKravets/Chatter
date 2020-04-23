using Chatter.Application.Contracts.Repositories;
using Chatter.Application.DataTransferObjects.Chats;
using Chatter.DAL.StoredProcedures.Chats;
using Quantum.DAL.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.DAL.Repositories
{
    internal class ChatRepository : IChatRepository
    {
        private readonly StoredProcedureExecutor _procedureExecutor;

        public ChatRepository(StoredProcedureExecutor procedureExecutor)
        {
            _procedureExecutor = procedureExecutor;
        }

        public Task<int> CreateAsync(CreateChatModel model)
        {
            return _procedureExecutor.ExecuteAsync(new SPCreateChat 
            { 
                Name = model.Name, 
                ChatTypeId = model.ChatTypeId, 
                CreatorId = model.CreatorId 
            });
        }

        public Task<int> DeleteAsync(int chatId)
        {
            return _procedureExecutor.ExecuteAsync(new SPDeleteChat 
            { 
                Id = chatId 
            });
        }

        public Task<ChatModel> GetAsync(int chatId)
        {
            return _procedureExecutor.ExecuteWithObjectResponseAsync<ChatModel>(new SPGetChatById 
            { 
                Id = chatId 
            });
        }

        public Task<ICollection<ChatModel>> GetAsync()
        {
            return _procedureExecutor.ExecuteWithListResponseAsync<ChatModel>(new SPGetChats());
        }

        public Task<ICollection<ChatModel>> GetAsync(int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<ChatModel> GetChatByNameAsync(string name)
        {
            return _procedureExecutor.ExecuteWithObjectResponseAsync<ChatModel>(new SPGetChatByName 
            { 
                Name = name 
            });
        }

        public Task<int> UpdateAsync(int id, UpdateChatModel model)
        {
            return _procedureExecutor.ExecuteAsync(new SPUpdateChat 
            { 
                Id = id, 
                Name = model.Name 
            });
        }
    }
}
