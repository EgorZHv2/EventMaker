using EventMaker.Infrastructure;
using EventMaker.Models.ViewModels;

namespace EventMaker.Services.Interfaces
{
    public interface IDirectionService
    {
        Task<Result<DirectionListViewModel>> GetAllDirectionsAsync();
        Task<Result<int>> CreateDirectionAsync(CreateDirectionViewModel viewModel);
    }
}
