namespace Chatter.Domain.Entities
{
    public class ChatUser
    {
        public string UserId { get; set; }
        public int ChatId { get; set; }

        public User User { get; set; }
        public Chat Chat { get; set; }

        //public UserRole Role { get; set; }
    }
}
