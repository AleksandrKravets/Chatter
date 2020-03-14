using Chatter.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface IChatUserRepository
    {
        Task<ChatUser> GetAsync(int id);
        Task<IEnumerable<User>> GetUsersByChatIdAsync(int chatId);
        Task<IEnumerable<Chat>> GetUserChatsAsync(int userId);
        //Task<UserRole> GetChatUserRoleAsync(int chatId, int userId);
        Task<int> CreateAsync(ChatUser chatUser);
        Task<int> UpdateUserRoleAsync(int chatId, int userId, UserRole userRole/*, int newRoleId*/);
        Task<int> DeleteAsync(int chatUserId);
        Task<ChatUser> GetChatUserByKeysAsync(int chatId, int userId);
        Task<int> DeleteChatUserByChatIdAndUserIdAsync(int chatId, int userId);
    }
}
