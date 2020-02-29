using System.Collections.Generic;

namespace Chatter.Domain.Entities
{
    public class User
    {
        public ICollection<ChatUser> ChatUsers { get; set; }
    }
}
