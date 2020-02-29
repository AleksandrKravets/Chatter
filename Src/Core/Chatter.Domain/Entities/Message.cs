﻿using System;

namespace Chatter.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ChatId { get; set; }
    }
}
