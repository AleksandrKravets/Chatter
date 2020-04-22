namespace Chatter.Application.DataTransferObjects.Chats
{
    public class CreateChatModel
    {
        public string Name { get; set; }
        public int ChatType { get; set; }
        public int CreatorId { get; set; }
    }
}
