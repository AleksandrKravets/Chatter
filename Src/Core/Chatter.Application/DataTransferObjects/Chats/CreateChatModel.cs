namespace Chatter.Application.DataTransferObjects.Chats
{
    public class CreateChatModel
    {
        public string Name { get; set; }
        public int ChatTypeId { get; set; }
        public int CreatorId { get; set; }
    }
}
