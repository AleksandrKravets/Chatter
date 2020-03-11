using Chatter.Domain.Common;

namespace Chatter.Domain.Entities
{
    public class User : StoredEntity
    {
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }        
    }
}
