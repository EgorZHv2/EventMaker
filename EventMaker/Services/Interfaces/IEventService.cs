using EventMaker.Infrastructure;
using EventMaker.Models.ViewModels;
using EventMaker.Models.ViewModels.CreateEventView;

namespace EventMaker.Services.Interfaces
{
    public interface IEventService
    {
        Task<Result<int>> CreateEventAsync(CreateEventViewModel viewModel);
        Task<Result<EventViewModel>> GetEventByIdAsync(int id);
        Task<Result<DetailedEventListViewModel>> GetAllEventsAsync();
    }
}
