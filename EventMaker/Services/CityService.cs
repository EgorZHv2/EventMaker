using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventMaker.Data;
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

    }
}
