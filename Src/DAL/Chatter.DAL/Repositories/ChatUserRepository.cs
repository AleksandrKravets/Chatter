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

        public Task CreateAsync(ChatUser chatUser)
        {
            return _procedureExecutor.ExecuteAsync(new CreateChatUserSP 
            { 
                ChatId = chatUser.ChatId, 
                RoleId = chatUser.RoleId, 
                UserId = chatUser.UserId 
            });
        }

        public Task DeleteAsync(int chatUserId)
        {
            return _procedureExecutor.ExecuteAsync(new DeleteChatUserSP 
            { 
                Id = chatUserId 
            });
        }

        public Task<ChatUser> GetAsync(int id)
        {
            return _procedureExecutor.ExecuteOneAsync<ChatUser>(new GetChatUserSP 
            { 
                Id = id 
            });
        }

        public Task<UserRole> GetChatUserRoleAsync(int chatId, int userId)
        {
            return _procedureExecutor.ExecuteOneAsync<UserRole>(new GetChatUserRoleSP
            { 
                ChatId = chatId, 
                UserId = userId 
            });
        }

        public Task<IEnumerable<Chat>> GetUserChatsAsync(int userId)
        {
            return _procedureExecutor.ExecuteListAsync<Chat>(new GetUserChatsSP 
            { 
                UserId = userId 
            });
        }

        public Task<IEnumerable<User>> GetUsersByChatIdAsync(int chatId)
        {
            return _procedureExecutor.ExecuteListAsync<User>(new GetUsersByChatIdSP 
            { 
                ChatId = chatId 
            });
        }

        public Task UpdateUserRoleAsync(int chatId, int userId, int newRoleId)
        {
            return _procedureExecutor.ExecuteAsync(new UpdateChatUserRoleSP 
            { 
                ChatId = chatId, 
                UserId = userId, 
                RoleId = newRoleId 
            });
        }
    }
}
