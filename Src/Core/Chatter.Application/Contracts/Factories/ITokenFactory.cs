using Chatter.Domain.Dto;
using Chatter.Domain.Entities;

namespace Chatter.Application.Contracts.Factories
{
    public interface ITokenFactory
    {
        AccessToken GetAccessToken(User user);
        Domain.Dto.RefreshToken GetRefreshToken(int size = 32);
    }
}
