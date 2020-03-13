using Chatter.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface IChatUserRepository
    {
        Task<ChatUser> GetAsync(int id);
        Task<IEnumerable<ChatUser>> GetByChatIdAsync(int chatId);
        Task<IEnumerable<ChatUser>> GetByUserIdAsync(int userId);
        Task CreateAsync(ChatUser chatUser);
        Task UpdateUserRoleAsync(int chatUserId, int newRoleId);
        Task DeleteAsync(int chatUserId);
    }
}
