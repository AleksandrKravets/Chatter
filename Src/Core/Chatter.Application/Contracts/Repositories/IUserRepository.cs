using Chatter.Domain.Entities;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(int userId);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByNicknameAsync(string nickname);
        Task<int> CreateAsync(User user);
        Task<int> UpdateAsync(User user);
        Task<int> DeleteAsync(int userId);
        Task<User> GetAsync(string nickname, string email);
    }
}
