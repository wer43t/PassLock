using System.ComponentModel.DataAnnotations;

namespace VediGroup.Pages.Account
{
    public class LoginViewModel
    {
        [Required]
        [MinLength(4)]
        public string Username { get; set; }
        
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
