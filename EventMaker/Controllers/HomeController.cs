using AutoMapper;
using EventMaker.Data;
using EventMaker.Data.Entities;
using EventMaker.Models;
using EventMaker.Models.ViewModels;
using EventMaker.Models.ViewModels.OrganizerProfileView;
using EventMaker.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace EventMaker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IEventService _eventService;

        public HomeController(ILogger<HomeController> logger
            ,ApplicationDbContext context
            ,UserManager<User> userManager
            ,IMapper mapper
            ,IEventService eventService )
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _eventService = eventService;
        }
        [HttpGet]
        public IActionResult OrganizerProfile()
        {
            OrganizerProfileViewModel organizerProfileViewModel = new OrganizerProfileViewModel();
            organizerProfileViewModel = _mapper.Map<OrganizerProfileViewModel>(_userManager.GetUserAsync(User).Result);
            return View(organizerProfileViewModel);
        }

        [HttpGet]
        public  IActionResult UserWindow()
        {
            UserWindowViewModel userWindowViewModel = new UserWindowViewModel();
            User user1 =   _userManager.GetUserAsync(User).Result;
            userWindowViewModel.IdNumber = user1.IdNumber;
            userWindowViewModel.Name = user1.FirstName;
            userWindowViewModel.UserProfilePath = "/logo1";
            return View(userWindowViewModel);
        }
        public IActionResult DetailedEvent(int id)
        {

        }
        public IActionResult Index()
        {
            DetailedEventListViewModel model = _eventService.GetAllEventsAsync().Result.Value;
            
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}