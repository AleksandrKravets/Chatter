namespace Chatter.Application.DataTransferObjects.Chats
{
    public class ChatModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ChatTypeId { get; set; }
        public long CreatorId { get; set; }
    }
}
