using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventMaker.Data;
using EventMaker.Data.Entities;
using EventMaker.Infrastructure;
using EventMaker.Models.ViewModels;
using EventMaker.Models.ViewModels.CreateEventView;
using EventMaker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventMaker.Services
{
    public class EventService:IEventService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EventService> _logger;
        private readonly IMapper _mapper;
        private readonly IDirectionService _directionService;
        private readonly ICityService _cityService;
        public EventService(ApplicationDbContext context, ILogger<EventService> logger, IMapper mapper, IDirectionService directionService, ICityService cityService)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _directionService = directionService;
            _cityService = cityService;
        }
        public  async Task<Result<int>> CreateEventAsync(CreateEventViewModel viewModel)
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

        public async Task<Result<EventViewModel>> GetEventByIdAsync(int id)
        {
            var eventModel = await _context.Events.FindAsync(id);

            if (eventModel is null)
            {
                _logger.LogError($"Событие с id - {id} не найдено");
                return Result<EventViewModel>.Failure("Событие не найдено", 404);
            }

            EventViewModel eventResult = null;

            try
            {
                eventResult = _mapper.Map<EventViewModel>(eventModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Маппинг завершился с ошибкой: {ex}");
                return Result<EventViewModel>.Failure("Произошла внутренняя ошибка сервера", 500);
            }

            return Result<EventViewModel>.Success(eventResult);
        }

        public async Task<Result<EventListViewModel>> GetAllEventsAsync()
        {
            var events = await _context.Events.ToListAsync();

            EventListViewModel eventList = new EventListViewModel();

            try
            {
                eventList.Events.AddRange(_context.Events.ProjectTo<EventViewModel>(_mapper.ConfigurationProvider));
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Маппинг завершился с ошибкой: {ex}");
                return Result<EventListViewModel>.Failure("Произошла внутренняя ошибка сервера", 500);
            }

            return Result<EventListViewModel>.Success(eventList);
        }
    }
}
