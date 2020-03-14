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
            return _procedureExecutor.ExecuteAsync(new CreateChatUserSP 
            { 
                ChatId = chatUser.ChatId, 
                //RoleId = chatUser.RoleId, 
                UserId = chatUser.UserId,
                Role = (int)chatUser.UserRole
            });
        }

        public Task<int> DeleteAsync(int chatUserId)
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

        /*public Task<UserRole> GetChatUserRoleAsync(int chatId, int userId)
        {
            return _procedureExecutor.ExecuteOneAsync<UserRole>(new GetChatUserRoleSP
            { 
                ChatId = chatId, 
                UserId = userId 
            });
        }*/

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

        public Task<int> UpdateUserRoleAsync(int chatId, int userId, UserRole userRole/*, int newRoleId*/)
        {
            return _procedureExecutor.ExecuteAsync(new UpdateChatUserRoleSP 
            { 
                ChatId = chatId, 
                UserId = userId, 
                //RoleId = newRoleId 
                Role = (int)userRole
            });
        }

        public Task<ChatUser> GetChatUserByKeysAsync(int chatId, int userId)
        {
            return _procedureExecutor.ExecuteOneAsync<ChatUser>(new GetChatUserByKeysSP 
            { 
                ChatId = chatId, 
                UserId = userId
            });
        }

        public Task<int> DeleteChatUserByChatIdAndUserIdAsync(int chatId, int userId)
        {
            return _procedureExecutor.ExecuteAsync(new DeleteChatUserByChatIdAndUserIdSP 
            { 
                ChatId = chatId,
                UserId = userId 
            });
        }
    }
}