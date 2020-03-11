using Chatter.Domain.Common;
using System;

namespace Chatter.Domain.Entities
{
    public class Message : StoredEntity
    {
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }

        public int ChatId { get; set; }
    }
}
