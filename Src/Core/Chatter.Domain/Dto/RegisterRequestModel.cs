using System.ComponentModel.DataAnnotations;

namespace Chatter.Domain.Dto
{
    public class RegisterRequestModel
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
