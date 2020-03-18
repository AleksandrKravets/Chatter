namespace Chatter.Domain.Dto
{
    public class UpdateChatRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int ChatTypeId { get; set; }
        public int ChatType { get; set; }
        public int CreatorId { get; set; }
    }
}
