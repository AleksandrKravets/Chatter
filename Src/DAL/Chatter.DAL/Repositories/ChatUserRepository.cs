using Chatter.Application.Contracts.Repositories;
using Chatter.DAL.StoredProcedures.ChatsUsers;
using Quantum.DAL.Infrastructure;
using System.Threading.Tasks;

namespace Chatter.DAL.Repositories
{
    internal class ChatUserRepository : IChatUserRepository
    {
        private readonly StoredProcedureExecutor _procedureExecutor;

        public ChatUserRepository(StoredProcedureExecutor procedureExecutor)
        {
            _procedureExecutor = procedureExecutor;
        }

        public Task<int> CreateAsync(long userId, long chatId, int userRoleId)
        {
            return _procedureExecutor.ExecuteAsync(new SPCreateChatUser
            {
                UserId = userId,
                ChatId = chatId,
                RoleId = userRoleId
            });
        }

        public Task<int> DeleteAsync(long chatUserId)
        {
            return _procedureExecutor.ExecuteAsync(new SPDeleteChatUserById
            {
                Id = chatUserId
            });
        }

        public Task<int> DeleteAsync(long userId, long chatId)
        {
            return _procedureExecutor.ExecuteAsync(new SPDeleteChatUser
            {
                UserId = userId, 
                ChatId = chatId
            });
        }
    }
}