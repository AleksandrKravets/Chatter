using Chatter.Domain.Dto;
using Chatter.Domain.Entities;

namespace Chatter.WebUI.Factories.Contracts
{
    public interface ITokenFactory
    {
        AccessToken GetAccessToken(User user);
        Domain.Dto.RefreshToken GetRefreshToken(int size = 32);
    }
}
