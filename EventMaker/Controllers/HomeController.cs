using AutoMapper;
using EventMaker.Data;
using EventMaker.Data.Entities;
using EventMaker.Models;
using EventMaker.Models.ViewModels;
using EventMaker.Models.ViewModels.OrganizerProfileView;
using EventMaker.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace EventMaker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IEventService _eventService;
        private readonly IMemberService _memberService;
        private readonly IJuryService _juryService;
        

        public HomeController(ILogger<HomeController> logger
            ,ApplicationDbContext context
            ,UserManager<User> userManager
            ,IMapper mapper
            ,IEventService eventService
            ,IMemberService memberService
            ,IJuryService juryService)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _eventService = eventService;
            _memberService = memberService;
            _juryService = juryService;
        }
        [HttpGet]
        public IActionResult OrganizerProfile()
        {
            OrganizerProfileViewModel organizerProfileViewModel = new OrganizerProfileViewModel();
            organizerProfileViewModel = _mapper.Map<OrganizerProfileViewModel>(_userManager.GetUserAsync(User).Result);
            organizerProfileViewModel.UserProfile = _userManager.GetUserAsync(User).Result.UserProfile;
            return View(organizerProfileViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> OrganizerProfile(OrganizerProfileViewModel model) 
        {
            User user = _userManager.GetUserAsync(User).Result;
            if(model.ChangePassword == true)
            {
               
               var resultt = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
           
            }
            

            
            return RedirectToAction("UserWindow", "Home");
        }
 
        [HttpGet]
        public  IActionResult UserWindow()
        {
            UserWindowViewModel userWindowViewModel = new UserWindowViewModel();
            User user1 =   _userManager.GetUserAsync(User).Result;
            userWindowViewModel.IdNumber = user1.IdNumber;
            userWindowViewModel.Name = user1.FirstName;

            return View(userWindowViewModel);
        }
       
        public IActionResult DetailedEvent([FromQuery]int Id)
        {
         DetailedEventViewModel model = _eventService.GetDetailedEventByIdAsync(Id).Result.Value;
                return View(model); 
           
        }

        [HttpGet]
        public IActionResult MembersList()
        {
            MemberListViewModel model = new MemberListViewModel();
            model = _memberService.GetAllMembersAsync().Result.Value;

            return View(model);

        }
        [HttpGet]
        public IActionResult JuryList()
        {
            JuriListViewModel juriListViewModel = new JuriListViewModel();
            juriListViewModel = _juryService.GetAllJuryAsync().Result.Value;
            return View(juriListViewModel);

        }

        public IActionResult Index()
        {
            DetailedEventListViewModel model = _eventService.GetAllDetailedEventsAsync().Result.Value;
            
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
       
    }
}