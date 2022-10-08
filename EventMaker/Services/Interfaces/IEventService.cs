using EventMaker.Infrastructure;
using EventMaker.Models.ViewModels;

namespace EventMaker.Services.Interfaces
{
    public interface IEventService
    {
        Task<Result<int>> CreateEventAsync(CreateEventViewModel viewModel);
        Task<Result<DetailedEventViewModel>> GetDetailedEventByIdAsync(int id);
        Task<Result<DetailedEventListViewModel>> GetAllDetailedEventsAsync();
    }
}
