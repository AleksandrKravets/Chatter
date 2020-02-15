using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Chatter.Domain.Entities
{
    public class User : IdentityUser
    {
        public ICollection<ChatUser> ChatUsers { get; set; }
    }
}
