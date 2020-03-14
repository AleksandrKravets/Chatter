using Chatter.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface IChatTypeRepository
    {
        Task<ChatType> GetAsync(int id);
        Task<IEnumerable<ChatType>> GetAllAsync();
        Task CreateAsync(ChatType chatType);
        Task DeleteAsync(int chatTypeId);
    }
}
