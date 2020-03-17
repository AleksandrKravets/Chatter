using System.Collections.Generic;
using System.Security.Claims;

namespace Chatter.API.Infrastructure.Contracts
{
    public interface IIdentityHelper
    {
        IEnumerable<Claim> GetUserClaims(ClaimsPrincipal user);
        int GetUserIdentifier(ClaimsPrincipal user); 
    }
}
