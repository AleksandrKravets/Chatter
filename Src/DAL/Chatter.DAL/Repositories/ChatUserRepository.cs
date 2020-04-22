using Chatter.Application.Contracts.Repositories;
using Chatter.DAL.Infrastructure;
using Chatter.DAL.StoredProcedures.ChatUsers;
using Chatter.Domain.Entities;
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

        public Task<int> CreateAsync(ChatUser chatUser)
        {
        }

        public Task<int> DeleteAsync(int chatUserId)
        {
        }

        public Task<ChatUser> GetAsync(int id)
        {
        }

        public Task<IEnumerable<Chat>> GetUserChatsAsync(int userId)
        {
        }

        public Task<IEnumerable<User>> GetUsersByChatIdAsync(int chatId)
        {
        }

        public Task<int> UpdateUserRoleAsync(int chatId, int userId, UserRole userRole/*, int newRoleId*/)
        {
        }

        public Task<ChatUser> GetChatUserByKeysAsync(int chatId, int userId)
        {
        }

        public Task<int> DeleteChatUserByChatIdAndUserIdAsync(int chatId, int userId)
        {
        }
    }
}