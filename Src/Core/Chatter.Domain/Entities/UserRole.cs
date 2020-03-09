using Chatter.Domain.Common;

namespace Chatter.Domain.Entities
{
    public class UserRole : StoredEntity<int>
    {
        public string RoleName { get; set; }
    }
}
