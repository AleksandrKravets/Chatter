using Chatter.Application.Contracts.Repositories;
using Chatter.DAL.Infrastructure;
using Chatter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.DAL.Repositories
{
    public class ChatUserRepository : IChatUserRepository
    {
        private readonly StoredProcedureExecutor _procedureExecutor;

        public ChatUserRepository(StoredProcedureExecutor procedureExecutor)
        {
            _procedureExecutor = procedureExecutor;
        }

        public Task CreateAsync(ChatUser chatUser)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int chatUserId)
        {
            throw new NotImplementedException();
        }

        public Task<ChatUser> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ChatUser>> GetByChatIdAsync(int chatId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ChatUser>> GetByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserRoleAsync(int chatUserId, int newRoleId)
        {
            throw new NotImplementedException();
        }
    }
}
