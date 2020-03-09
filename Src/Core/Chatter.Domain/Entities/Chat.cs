using Chatter.Domain.Common;

namespace Chatter.Domain.Entities
{
    public class Chat : StoredEntity<int>
    {
        public string Name { get; set; }
        public ChatType Type { get; set; }

        //public ICollection<ChatUser> Users { get; set; }
    }
}
