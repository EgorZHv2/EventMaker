using EventMaker.Infrastructure;
using EventMaker.Models.ViewModels;

namespace EventMaker.Services.Interfaces
{
    public interface IActivityService
    {
        Task<Result<int>> CreateActivityAsync(CreateActivityViewModel viewModel);
        Task<Result<ActivityListViewModel>> GetAllActivitiesByEventId(int eventId);
    }
}
