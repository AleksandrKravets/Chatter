namespace Chatter.Application.DataTransferObjects.Messages
{
    public class UpdateMessageModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int SenderId { get; set; }
        public int ChatId { get; set; }
    }
}
