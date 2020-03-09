using Chatter.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chatter.Domain.Entities
{
    public class User : StoredEntity<int>
    {
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }

        // public ICollection<ChatUser> ChatUsers { get; set; }


        
    }
}
