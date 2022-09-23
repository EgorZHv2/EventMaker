using AutoMapper;
using EventMaker.Data;
using EventMaker.Data.Entities;
using EventMaker.Infrastructure;
using EventMaker.Models.ViewModels;
using EventMaker.Models.ViewModels.CreateEventView;
using EventMaker.Services.Interfaces;

namespace EventMaker.Services
{
    public class EventService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EventService> _logger;
        private readonly IMapper _mapper;
        private readonly DirectionService _directionService;
        private readonly CityService _cityService;
        public EventService(ApplicationDbContext context, ILogger<EventService> logger, IMapper mapper, DirectionService directionService, CityService cityService)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _directionService = directionService;
            _cityService = cityService;
        }
        async Task<Result<int>> CreateEventAsync(CreateEventViewModel viewModel)
        {
            var maxDate = viewModel.StartDate.AddDays(1);

            if (viewModel.EndDate > maxDate)
            {
                _logger.LogError($"Произошла ошибка при попытке получить дату окнчания мероприятия");
                return Result<int>.Failure("Разница между датой начала и датой конца не должна превышать 24 часа");
            }

            //if (string.IsNullOrEmpty(viewModel.DirectionName)) ToDo Сделать нормальную проверку на js
            //{
            //    _logger.LogError($"Мероприятие не выбрано");
            //    return Result<int>.Failure("Обязательное поле 'Мероприятие' пустое",400);
            //}
            //if (string.IsNullOrEmpty(viewModel.DirectionName))
            //{
            //    _logger.LogError($"Город не выбран");
            //    return Result<int>.Failure("Обязательное поле 'Город' пустое",400);
            //}
            var directionmodel = await _directionService.GetDirectionByNameAsync(viewModel.DirectionName);
            if (directionmodel.Successed)
            {
                viewModel.DirectionId = directionmodel.Value.Id;
            }
            else if(!directionmodel.Successed && directionmodel.StatusCode == 404)
            {

                var newdirection = _directionService.CreateDirectionAsync(new CreateDirectionViewModel { Name = viewModel.DirectionName });
                if (newdirection.Result.Successed)
                {
                    viewModel.DirectionId = newdirection.Result.Value;
                }
            }

            var citymodel = await _cityService.GetCityByNameAsync(viewModel.CityName);
            if (citymodel.Successed)
            {
                viewModel.CityId = citymodel.Value.Id;
            }
            else if(!citymodel.Successed && citymodel.StatusCode == 404)
            {
                var newcity = _cityService.CreateCityAsync(new CreateCityViewModel { Name = viewModel.CityName });
                if (newcity.Result.Successed)
                {
                    viewModel.CityId = newcity.Result.Value;
                }
            }

            Event eventt = new Event();
            try
            {
                eventt = _mapper.Map<Event>(viewModel);
            }
            catch(Exception e)
            {
                _logger.LogError($"Маппинг завершился с ошибкой: {e}");
                return Result<int>.Failure("Произошла внутренняя ошибка сервера", 500);
            }
            await _context.Events.AddAsync(eventt);
            return Result<int>.Success(eventt.Id);
        }
    }
}
