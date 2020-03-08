namespace Chatter.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }

        // public ICollection<ChatUser> ChatUsers { get; set; }
    }
}
