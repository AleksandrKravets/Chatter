using Chatter.Domain.Common;

namespace Chatter.Domain.Entities
{
    public class ChatUser : StoredEntity
    {
        public int UserId { get; set; }
        public int ChatId { get; set; }
        public int RoleId { get; set; }
    }
}
