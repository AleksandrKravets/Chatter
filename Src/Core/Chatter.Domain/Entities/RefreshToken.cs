using Chatter.Domain.Common;
using System;

namespace Chatter.Domain.Entities
{
    public class RefreshToken : StoredEntity
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool Active => DateTime.UtcNow <= Expires;

        public int UserId { get; set; }
    }
}
