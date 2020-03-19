using System.ComponentModel.DataAnnotations;

namespace Chatter.Domain.Dto
{
    public class CreateMessageRequestModel
    {
        [Required] public string Text { get; set; }
        [Required] public int ChatId { get; set; }
        [Required] public int SenderId { get; set; }
    }
}
