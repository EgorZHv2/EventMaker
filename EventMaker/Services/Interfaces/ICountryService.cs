using EventMaker.Infrastructure;
using EventMaker.Models.ViewModels;

namespace EventMaker.Services.Interfaces
{
    public interface ICountryService
    {
        Task<Result<CountryListViewModel>> GetAllCountriesAsync();
    }
}
