using System.ComponentModel.DataAnnotations;

namespace Chatter.WebUI.Models.Auth
{
    public class RefreshTokenRequestModel
    {
        [Required]
        public string AccessToken { get; set; }
        [Required]
        public string RefreshToken { get; set; }
    }
}
