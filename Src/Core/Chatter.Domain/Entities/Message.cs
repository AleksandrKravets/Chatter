using Chatter.Domain.Common;
using System;

namespace Chatter.Domain.Entities
{
    public class Message : StoredEntity
    {
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }
        // IsUpdated
        public int ChatId { get; set; }
        public int SenderId { get; set; }
    }
}
