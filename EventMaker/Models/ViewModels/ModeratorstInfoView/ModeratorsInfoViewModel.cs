namespace EventMaker.Models.ViewModels.ModeratorstInfoView
{
    public class ModeratorsInfoViewModel
    {
        public List<ModeratorSearchViewModel> ModeratorSurname { get; set; } = new List<ModeratorSearchViewModel>();
        public List<EventViewModel> Events { get; set; } = new List<EventViewModel>();
        public List<ModeratorViewModel> ModeratorsList = new List<ModeratorViewModel>();
    }
}
