using Chatter.Application.DataTransferObjects.ChatTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface IChatTypeRepository
    {
        Task<ICollection<ChatTypeModel>> GetAllAsync();
    }
}
