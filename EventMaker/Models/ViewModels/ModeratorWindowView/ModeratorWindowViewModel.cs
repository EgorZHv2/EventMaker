namespace EventMaker.Models.ViewModels.ModeratorWindowView
{
    public class ModeratorWindowViewModel
    {
        public List<DirectionViewModel> Directions { get; set; } = new List<DirectionViewModel>();
        public List<EventViewModel> Events { get; set; } = new List<EventViewModel>();
        public List<ModeratorWindowView.ModeratorActivityViewModel> Activities { get; set; } = new List<ModeratorWindowView.ModeratorActivityViewModel>(); 
    }
}
