using Chatter.Application.Infrastructure;
using Chatter.Domain.Dto;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface IMessageService
    {
        Task<IResponse> CreateAsync(CreateMessageRequestModel message);
        Task<IResponse> UpdateAsync(UpdateMessageRequestModel message);
        Task<IResponse> DeleteAsync(int messageId);
        Task<IResponse> GetAsync(int messageId);
        Task<IResponse> GetAllAsync(int chatId);
        Task<IResponse> GetAsync(int chatId, int pageIndex, int pageSize);
    }
}
