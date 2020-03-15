using Chatter.Domain.Common;
using System;

namespace Chatter.Domain.Entities
{
    public class RefreshToken : StoredEntity
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public int UserId { get; set; }

        public bool IsActive() => DateTime.UtcNow <= Expires;
    }
}
