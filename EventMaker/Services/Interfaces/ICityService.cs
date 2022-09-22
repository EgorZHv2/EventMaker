using EventMaker.Infrastructure;
using EventMaker.Models.ViewModels;

namespace EventMaker.Services.Interfaces
{
    public interface ICityService
    {
        Task<Result<CityListViewModel>> GetAllCitiesAsync();
    }
}
