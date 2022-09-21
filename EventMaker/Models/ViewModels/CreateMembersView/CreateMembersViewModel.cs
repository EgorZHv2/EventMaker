using EventMaker.Data.Entities;
using EventMaker.Data.Enums;

namespace EventMaker.Models.ViewModels.CreateMembersView
{
    public class CreateMembersViewModel
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateOnly Date { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserProfilePath { get; set; }
        public string Password { get; set; }
        public string PasswordRe { get; set; }
    }
}
