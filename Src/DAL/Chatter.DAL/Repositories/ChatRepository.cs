using Chatter.Application.Contracts.Repositories;
using Chatter.Application.DataTransferObjects.Chats;
using Quantum.DAL.Infrastructure;
using Quantum.DAL.Infrastructure.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.DAL.Repositories
{
    [ProcedureName("CreateChat")]
    internal class SPCreateChat : StoredProcedure
    {
        [InParameter] public string Name;
        [InParameter] public int CreatorId;
        [InParameter] public int ChatTypeId;
    }

    [ProcedureName("DeleteChat")]
    internal class SPDeleteChat : StoredProcedure
    {
        [InParameter] public int Id;
    }

    [ProcedureName("GetChat")]
    internal class SPGetChatById : StoredProcedure
    {
        [InParameter] public int Id;
    }

    [ProcedureName("GetChats")]
    internal class SPGetChats : StoredProcedure
    {
    }

    [ProcedureName("UpdateChat")]
    internal class SPUpdateChat : StoredProcedure
    {
        [InParameter] public int Id;
        [InParameter] public string Name;
    }

    [ProcedureName("GetChatByName")]
    internal class SPGetChatByName : StoredProcedure
    {
        [InParameter] public string Name;
    }
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
