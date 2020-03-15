using System;
using System.ComponentModel.DataAnnotations;

namespace Chatter.WebUI.Models.Message
{
    public class CreateMessageViewModel
    {
        [Required] public string Text { get; set; }
        [Required] public int ChatId { get; set; }
        [Required] public int SenderId { get; set; }
    }
}
