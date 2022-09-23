using EventMaker.Infrastructure;
using EventMaker.Models.ViewModels;

namespace EventMaker.Services.Interfaces
{
    public interface ICityService
    {
        Task<Result<CityListViewModel>> GetAllCitiesAsync();
        Task<Result<int>> CreateCityAsync(CreateCityViewModel viewModel);
        Task<Result<CityViewModel>> GetCityByNameAsync(string cityname);
    }
}
