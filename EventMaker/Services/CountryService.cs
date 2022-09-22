using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventMaker.Data;
using EventMaker.Infrastructure;
using EventMaker.Models.ViewModels;
using EventMaker.Services.Interfaces;

namespace EventMaker.Services
{
    public class CountryService:ICountryService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CountryService> _logger;
        private readonly IMapper _mapper;
        public CountryService(ApplicationDbContext context, ILogger<CountryService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Result<CountryListViewModel>> GetAllCountriesAsync()
        {
            CountryListViewModel countryListViewModel = new CountryListViewModel();
            try
            {
                countryListViewModel.CountryList.AddRange(_context.Countries.ProjectTo<CountryViewModel>(_mapper.ConfigurationProvider));
            }
            catch (Exception e)
            {
                _logger.LogError($"Маппинг завершился с ошибкой {e}");
                return Result<CountryListViewModel>.Failure("Произошла внутренняя ошибка сервера", 500);
            }
            return Result<CountryListViewModel>.Success(countryListViewModel);
        }
    }
}
