using EventMaker.Data.Entities;
using EventMaker.Data.Enums;
using Microsoft.Extensions.FileProviders;

namespace EventMaker.Models.ViewModels.CreateMembersView
{
    public class CreateMembersViewModel
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateOnly Date { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile UserProfile { get; set; }
        public string Password { get; set; }
        public string PasswordRe { get; set; }
    }
}
