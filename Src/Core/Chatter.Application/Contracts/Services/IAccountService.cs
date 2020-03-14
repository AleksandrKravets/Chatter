using Chatter.Application.Infrastructure;
using Chatter.Domain.Dto;
using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface IAccountService
    {
        Task<ResponseObject> RegisterAsync(RegisterRequestModel model);
    }
}
