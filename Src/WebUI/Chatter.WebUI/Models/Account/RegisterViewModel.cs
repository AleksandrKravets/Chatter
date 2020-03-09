using System.ComponentModel.DataAnnotations;

namespace Chatter.WebUI.Models.Account
{
    public class RegisterViewModel
    {
        [Required]
        public string Nickname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
