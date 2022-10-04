using EventMaker.Data;
using EventMaker.Data.Entities;
using EventMaker.Models;
using EventMaker.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace EventMaker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<User> userManager )
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        public  IActionResult UserWindow()
        {
            UserWindowViewModel userWindowViewModel = new UserWindowViewModel();
            User user1 =   _userManager.GetUserAsync(User).Result;
            userWindowViewModel.IdNumber = user1.IdNumber;
            userWindowViewModel.Name = user1.FirstName;
            userWindowViewModel.UserProfilePath = "/logo1";
            return View(userWindowViewModel);
        }
        public IActionResult Index()
        {
            return View();
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