using Chatter.Application.Contracts.Repositories;
using Chatter.DAL.Infrastructure;
using Chatter.Domain.Entities;
using System;
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
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int chatTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ChatType>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ChatType> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ChatType chatType)
        {
            throw new NotImplementedException();
        }
    }
}
