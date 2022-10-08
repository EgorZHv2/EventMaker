namespace EventMaker.Models.ViewModels
{
    public class CreateActivityMainViewModel
    {
        public List<ActivityViewModel> activities { get; set; } = new List<ActivityViewModel>();
        public CreateActivityViewModel viewModel { get; set; } = new CreateActivityViewModel();
        public JuriListViewModel juri { get; set; } = new JuriListViewModel();
    }
}
