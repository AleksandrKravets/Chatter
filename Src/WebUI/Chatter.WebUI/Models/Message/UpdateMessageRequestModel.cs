namespace Chatter.API.Models.Message
{
    public class UpdateMessageRequestModel
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public int SenderId { get; set; }
    }
}
