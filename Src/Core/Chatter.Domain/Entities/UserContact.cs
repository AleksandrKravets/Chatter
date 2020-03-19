using Chatter.Domain.Common;

namespace Chatter.Domain.Entities
{
    public class UserContact : StoredEntity
    {
        public int UserId { get; set; }
        public int ContactUserId { get; set; }
    }
}
