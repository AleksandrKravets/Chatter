using Chatter.Application.DataTransferObjects.ChatTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface IChatTypeService
    {
        Task<ICollection<ChatTypeModel>> GetAllAsync();
    }
}
