using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventMaker.Data;
using EventMaker.Data.Entities;
using EventMaker.Infrastructure;
using EventMaker.Models.ViewModels;
using EventMaker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventMaker.Services
{
    public class CityService:ICityService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CityService> _logger;
        private readonly IMapper _mapper;
        public CityService(ApplicationDbContext context, ILogger<CityService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Result<CityListViewModel>> GetAllCitiesAsync()
        {
            CityListViewModel cityListViewModel = new CityListViewModel();
                     
            try
            {
                cityListViewModel.CityList.AddRange(_context.Cities.ProjectTo<CityViewModel>(_mapper.ConfigurationProvider));
            }
            catch(Exception e)
            {
                _logger.LogError($"Маппинг завершился с ошибкой {e}");
                return Result<CityListViewModel>.Failure("Произошла внутренняя ошибка сервера", 500);
            }
            return Result<CityListViewModel>.Success(cityListViewModel);
        }
        public async Task<Result<int>> CreateCityAsync(CreateCityViewModel viewModel)
        {
            City? city = null;
            try
            {
                city = _mapper.Map<City>(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Маппинг завершился с ошибкой: {ex}");
                return Result<int>.Failure("Произошла внутренняя ошибка сервера", 500);
            }

            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();

            return Result<int>.Success(city.Id);

        }
        public async Task<Result<CityViewModel>> GetCityByNameAsync(string cityname)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(d => d.Name == cityname);

            if (city is null)
            {
                _logger.LogError($"Направление {cityname} не найдено");
                return Result<CityViewModel>.Failure("Направление не найдено", 404);
            }

            CityViewModel? cityModel = null;

            try
            {
                cityModel = _mapper.Map<CityViewModel>(city);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Маппинг завершился с ошибкой: {ex}");
                return Result<CityViewModel>.Failure("Произошла внутренняя ошибка сервера", 500);
            }

            return Result<CityViewModel>.Success(cityModel);
        }

    }
}
