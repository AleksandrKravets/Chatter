using Chatter.Application.Contracts.Repositories;
using Chatter.Application.DataTransferObjects.ChatTypes;
using Chatter.DAL.StoredProcedures.ChatTypes;
using Quantum.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.DAL.Repositories
{
    internal class ChatTypeRepository : IChatTypeRepository
    {
        private readonly StoredProcedureExecutor _executor;

        public ChatTypeRepository(StoredProcedureExecutor executor)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        }

        public Task<ICollection<ChatTypeModel>> GetAllAsync()
        {
            return _executor.ExecuteWithListResponseAsync<ChatTypeModel>(new SPGetChatTypes());
        }
    }
}
