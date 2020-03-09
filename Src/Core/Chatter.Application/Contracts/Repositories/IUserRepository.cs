using Chatter.Domain.Entities;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(int userId);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByNickname(string nickname);
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int userId);
        Task<bool> CheckIfUserExist(string nickname, string email);
    }
}
