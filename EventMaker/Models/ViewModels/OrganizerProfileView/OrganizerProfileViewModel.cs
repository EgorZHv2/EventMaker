using EventMaker.Data.Entities;
using EventMaker.Data.Enums;

namespace EventMaker.Models.ViewModels.OrganizerProfileView
{
    public class OrganizerProfileViewModel
    {
        public int IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Patronimyc { get; set; }
        public Gender Gender { get; set; }
        public byte[]? UserProfile { get; set; }
        public DateTime? BirthDate { get; set; }
        public Country? Country { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public bool ChangePassword { get; set; }
        
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
