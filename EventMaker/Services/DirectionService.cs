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
    public class DirectionService:IDirectionService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DirectionService> _logger;
        private readonly IMapper _mapper;
        public DirectionService(ApplicationDbContext context, ILogger<DirectionService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Result<DirectionListViewModel>> GetAllDirectionsAsync()
        {
            DirectionListViewModel directionListViewModel = new DirectionListViewModel();
            try
            {
                directionListViewModel.DirectionList.AddRange(_context.Directions.ProjectTo<DirectionViewModel>(_mapper.ConfigurationProvider));
            }
            catch (Exception e)
            {
                _logger.LogError($"Маппинг завершился с ошибкой {e}");
                return Result<DirectionListViewModel>.Failure("Произошла внутренняя ошибка сервера", 500);
            }
            return Result<DirectionListViewModel>.Success(directionListViewModel);
        }
        public async Task<Result<int>> CreateDirectionAsync(CreateDirectionViewModel viewModel)
        {
            Direction? direction = null;
            try
            {
                direction = _mapper.Map<Direction>(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Маппинг завершился с ошибкой: {ex}");
                return Result<int>.Failure("Произошла внутренняя ошибка сервера", 500);
            }

            await _context.Directions.AddAsync(direction);
            await _context.SaveChangesAsync();

            return Result<int>.Success(direction.Id);
      
        }

        public async Task<Result<DirectionViewModel>> GetDirectionByNameAsync(string directionname)
        {
            var direction =  await _context.Directions.FirstOrDefaultAsync(d => d.Name == directionname);

            if (direction is null)
            {
                _logger.LogError($"Направление {directionname} не найдено");
                return Result<DirectionViewModel>.Failure("Направление не найдено", 404);
            }

            DirectionViewModel? directionModel = null;

            try
            {
                directionModel = _mapper.Map<DirectionViewModel>(direction);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Маппинг завершился с ошибкой: {ex}");
                return Result<DirectionViewModel>.Failure("Произошла внутренняя ошибка сервера", 500);
            }

            return Result<DirectionViewModel>.Success(directionModel);
        }

    }
}
