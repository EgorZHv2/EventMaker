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

            return Result<int>.Success(0);
        }
    }
}
