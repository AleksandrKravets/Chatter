using Chatter.Application.Infrastructure;
using Chatter.Domain.Dto;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface IAuthorizationService
    {
        Task<IResponse> AuthorizeAsync(LoginRequestModel model);
    }
}
