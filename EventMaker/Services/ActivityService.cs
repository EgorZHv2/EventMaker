using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventMaker.Data;
using EventMaker.Data.Entities;
using EventMaker.Infrastructure;
using EventMaker.Models.ViewModels;
using EventMaker.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EventMaker.Services
{
    public class ActivityService:IActivityService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ActivityService> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public ActivityService(ApplicationDbContext context, IMapper mapper, ILogger<ActivityService> logger, UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _userManager = userManager;
        }
        public  async Task<Result<int>> CreateActivityAsync(CreateActivityViewModel viewModel, int EventId)
        {
            Activity activity = new Activity();
            try
            {
                activity = _mapper.Map<Activity>(viewModel);
                activity.ModeratorId = viewModel.JuryId;
                activity.EventId = EventId;
            }
            catch(Exception e)
            {
                _logger.LogError($"Маппинг {viewModel.GetType()} в {typeof(Activity)} завершился ошибкой");
                return Result<int>.Failure("Внутренная ошибка сервера", 500);
            }
            await _context.Activities.AddAsync(activity);
            await _context.SaveChangesAsync();
            return Result<int>.Success(activity.Id);
        }
        public async Task<Result<ActivityListViewModel>> GetAllActivitiesByEventId(int eventId)
        {
            var eventmodel = await _context.Events.FindAsync(eventId);
            if(eventmodel is null)
            {
                _logger.LogError($"Мероприятие с ID {eventId} не найдено");
                return Result<ActivityListViewModel>.Failure("Мероприятие не найдено", 404);
            }
            var activitiesByEventId = _context.Activities.Where(e => e.EventId == eventId).ToList();
            
            if(activitiesByEventId is null)
            {
                _logger.LogError($"Активностей с ID {eventId} не найдено");
                return Result<ActivityListViewModel>.Failure("Активности не найдены", 404);
            }
            
            ActivityListViewModel viewmodel = new ActivityListViewModel();
            
            try
            {
                
                foreach (Activity activity in activitiesByEventId)
                {
                    viewmodel.ActivitiesList.Add(new ActivityViewModel { Name = activity.Name,
                    StartDate = activity.StartDate,
                    Jury = _userManager.FindByIdAsync(activity.ModeratorId).Result });
                    
                }
            }
            catch(Exception e)
            {
                _logger.LogError($"Маппинг  завершился с ошибкой: {e}");
                return Result<ActivityListViewModel>.Failure("Произошла внутренняя ошибка сервера", 500);
            }
            return Result<ActivityListViewModel>.Success(viewmodel);
        }
    }
}
