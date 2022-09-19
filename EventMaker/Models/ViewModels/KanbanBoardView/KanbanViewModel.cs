namespace EventMaker.Models.ViewModels.KanbanBoardView
{
    public class KanbanViewModel
    {
        public List<EventViewModel> KanbanEvents { get; set; } = new List<EventViewModel>();
        public List<ActivityViewModel> ActivityList { get; set; } = new List<ActivityViewModel>();
    }
}
