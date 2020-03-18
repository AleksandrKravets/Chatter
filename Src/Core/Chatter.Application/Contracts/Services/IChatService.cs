using Chatter.Application.Infrastructure;
using Chatter.Domain.Dto;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface IChatService
    {
        Task<IResponse> CreateAsync(CreateChatRequestModel chat);
        Task<IResponse> UpdateAsync(UpdateChatRequestModel chat);
        Task<IResponse> DeleteAsync(int chatId);
        Task<IResponse> GetAsync(int chatId);
        Task<IResponse> GetAsync();
        Task<IResponse> GetAsync(int pageIndex, int pageSize);
        Task<IResponse> JoinChatAsync(JoinChatRequestModel model);
        Task<IResponse> LeaveChatAsync(LeaveChatRequestModel model);
    }
}
