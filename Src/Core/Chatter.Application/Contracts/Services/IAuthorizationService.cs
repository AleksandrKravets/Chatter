using Chatter.Domain.Dto;
using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface IAuthorizationService
    {
        Task<Result<TokensResponseModel>> AuthorizeAsync(LoginRequestModel model);
    }
}
