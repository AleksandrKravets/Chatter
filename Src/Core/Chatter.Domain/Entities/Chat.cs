using Chatter.Domain.Common;

namespace Chatter.Domain.Entities
{
    public class Chat : StoredEntity
    {
        public string Name { get; set; }

        //public int ChatTypeId { get; set; }
        public int CreatorId { get; set; }
        public ChatType ChatType { get; set; }
    }
}
