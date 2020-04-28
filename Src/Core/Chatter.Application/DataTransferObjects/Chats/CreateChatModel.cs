namespace Chatter.Application.DataTransferObjects.Chats
{
    public class CreateChatModel
    {
        public string Name { get; set; }
        public long ChatTypeId { get; set; }
        public long CreatorId { get; set; }
    }
}
