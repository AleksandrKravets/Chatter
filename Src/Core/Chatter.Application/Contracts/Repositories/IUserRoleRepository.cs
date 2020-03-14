using Chatter.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface IUserRoleRepository
    {
        Task<UserRole> GetAsync(int id);
        Task<IEnumerable<UserRole>> GetAllAsync();
        Task<int> CreateAsync(UserRole userRole);
        Task<int> UpdateAsync(UserRole userRole);
        Task<int> DeleteAsync(int userRoleId);
    }
}
