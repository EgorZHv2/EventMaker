using Microsoft.Build.Framework;

namespace EventMaker.Areas.Account.Models
{
    public class LoginViewModel
    {
        [Required]
        public int IdNumber { get; set; }
        [Required]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
        [Required]
        public bool RememberMe { get; set; } 
    }
}
