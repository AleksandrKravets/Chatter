namespace Chatter.Application.DataTransferObjects.Messages
{
    public class CreateMessageModel
    {
        public string Text { get; set; }
        public int ChatId { get; set; }
        public int SenderId { get; set; }
    }
}
