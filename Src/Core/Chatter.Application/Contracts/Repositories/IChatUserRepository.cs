using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface IChatUserRepository
    {
        Task<int> CreateAsync(long userId, long chatId, int userRoleId);
        Task<int> DeleteAsync(long chatUserId);
        Task<int> DeleteAsync(long userId, long chatId);
    }
}
