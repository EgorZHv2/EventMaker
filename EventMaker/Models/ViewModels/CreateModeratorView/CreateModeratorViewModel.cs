using EventMaker.Data.Enums;

namespace EventMaker.Models.ViewModels.CreateModeratorView
{
    public class CreateModeratorViewModel
    {
        public int IdNumber { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<DirectionViewModel> Directions { get; set; } = new List<DirectionViewModel>();
        public bool AttachToEvent { get; set; }
        public List<EventViewModel> Events { get; set; } = new List<EventViewModel>();
        public string UserProfilePath { get; set; }
        public string Password { get; set; }
        public string PasswordRe { get; set; }
        public bool VisiblePassword { get; set; }
    }
}
