using Chatter.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface IUserRoleRepository
    {
        Task<UserRole> GetAsync(int id);
        Task<IEnumerable<UserRole>> GetAllAsync();
        Task CreateAsync(UserRole userRole);
        Task UpdateAsync(UserRole userRole);
        Task DeleteAsync(int userRoleId);
    }
}
