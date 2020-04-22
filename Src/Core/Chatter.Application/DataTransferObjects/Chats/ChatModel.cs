namespace Chatter.Application.DataTransferObjects.Chats
{
    public class ChatModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ChatType { get; set; }
        public int CreatorId { get; set; }
    }
}
