using Chatter.Domain.Entities;

namespace Chatter.WebUI.Factories.Contracts
{
    public interface ITokenFactory
    {
        object GetToken(User user);
    }
}
