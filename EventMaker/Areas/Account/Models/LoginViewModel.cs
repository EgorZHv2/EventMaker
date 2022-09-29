namespace EventMaker.Areas.Account.Models
{
    public class LoginViewModel
    {
        public int NumberId { get; set; }
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}
