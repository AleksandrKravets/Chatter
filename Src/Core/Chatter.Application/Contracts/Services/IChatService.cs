using Chatter.Application.Infrastructure;
using Chatter.Domain.Entities;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface IChatService
    {
        Task<IResponse> CreateAsync(Chat chat);
        Task<IResponse> UpdateAsync(Chat chat);
        Task<IResponse> DeleteAsync(int chatId);
        Task<IResponse> GetAsync(int chatId);
        Task<IResponse> GetAsync();
        Task<IResponse> GetAsync(int pageIndex, int pageSize);
        Task<IResponse> JoinChatAsync(int chatId, int userId);
        Task<IResponse> LeaveChatAsync(int chatId, int userId);
    }
}
