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
        Task<UserRole> GetChatUserRoleAsync(int chatId, int userId);
        Task CreateAsync(ChatUser chatUser);
        Task UpdateUserRoleAsync(int chatId, int userId, int newRoleId);
        Task DeleteAsync(int chatUserId);
    }
}
