using AutoMapper;
using EventMaker.Data.Entities;
using EventMaker.Data;
using EventMaker.Models.ViewModels;
using EventMaker.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace EventMaker.Controllers
{
    public class EventController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IEventService _eventService;
        private readonly IDirectionService _directionService;
        private readonly IActivityService _activityService;
        private readonly ICityService _cityService;
        private readonly IJuryService _juryService;
        public EventController(ILogger<HomeController> logger
            , ApplicationDbContext context
            , UserManager<User> userManager
            , IMapper mapper
            , IEventService eventService
            , IDirectionService directionService
            , IActivityService activityService
            , ICityService cityService
            , IJuryService juryService)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _eventService = eventService;
            _directionService = directionService;
            _activityService = activityService;
            _cityService = cityService;
            _juryService = juryService;
        }
        public IActionResult EventsList()
        {
            DetailedEventListViewModel model = _eventService.GetAllDetailedEventsAsync().Result.Value;
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateEvent()
        {
            CreateEventViewModel model = new CreateEventViewModel();
            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now;
            model.Directions = _directionService.GetAllDirectionsAsync().Result.Value.DirectionList;
            model.Cities = _cityService.GetAllCitiesAsync().Result.Value.CityList;   

            
  
             
            return View(model);
        }
        [HttpPost]
        public  async Task<IActionResult> CreateEvent(CreateEventViewModel model)
        {

            model.OrganizerId = _userManager.GetUserId(User);

            var result = await _eventService.CreateEventAsync(model);
            
            
             return RedirectToAction("EventsList", "Event");
        }
        [HttpGet]
        public IActionResult ActivitiesList([FromQuery] int Id)
        {
            CreateActivityMainViewModel createActivityMainViewModel = new CreateActivityMainViewModel();
            createActivityMainViewModel.viewModel.StartDate = DateTime.Now;
            createActivityMainViewModel.activities = _activityService.GetAllActivitiesByEventId(Id).Result.Value.ActivitiesList;
            createActivityMainViewModel.juri = _juryService.GetAllJuryShortListAsync().Result.Value;
            return View(createActivityMainViewModel);
        }
        [HttpPost]
        public IActionResult ActivitiesList([FromQuery] int Id,CreateActivityMainViewModel model) 
        {
            _activityService.CreateActivityAsync(model.viewModel, Id);
            return RedirectToAction("EventsList", "Event");
        }
    }
}
