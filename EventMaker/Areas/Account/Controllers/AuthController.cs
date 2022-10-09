using EventMaker.Areas.Account.Models;
using EventMaker.Data.Entities;
using EventMaker.Services;
using EventMaker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Drawing;

namespace EventMaker.Areas.Account.Controllers
{
    public class AuthController : Controller
    {
        Random random = new Random();
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AuthController> _logger;
        private readonly IImageConverter _imageConverter;
        public AuthController(UserManager<User> userManager = null,
                              SignInManager<User> signInManager = null,
                              ILogger<AuthController> logger = null,
                              IImageConverter imageConverter = null)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _imageConverter = imageConverter;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginmodel)
        {
           
            var user = await _userManager.FindByNameAsync(loginmodel.IdNumber.ToString());
            var result = await _signInManager.PasswordSignInAsync(loginmodel.IdNumber.ToString(),
               loginmodel.Password, loginmodel.RememberMe, false);
           
            if (result.Succeeded)
            {
                user.LastLogin = DateTime.Now;
                _userManager?.UpdateAsync(user);               
                return RedirectToAction("UserWindow", "Home", new { area = "" });
                
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public IActionResult Registration()
        {
            RegistrationViewModel model = new RegistrationViewModel();
            return View(model); 
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            
                User user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Patronimyc = model.Patronymic,
                    BirthDate = model.BirthDate,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Gender = model.Gender,
                };

                user.UserProfile = _imageConverter.ConvertFormFileToByte(model.UserProfile);
                user.IdNumber = random.Next(0,1000000);
                user.UserName = user.IdNumber.ToString();

                var result = await _userManager.CreateAsync(user, model.Password);

                var roleName = "Member";
                await _userManager.AddToRoleAsync(user, roleName);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("OrganizerProfile", "Home", new { area = "" });
                }
                
            
            return View(model);
        }

        [HttpGet]
        public IActionResult MemberRegistration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> MemberRegistration(RegistrationViewModel model)
        {
            User user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Patronimyc = model.Patronymic,
                    BirthDate = model.BirthDate,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Gender = model.Gender,
                };

                user.UserProfile = _imageConverter.ConvertFormFileToByte(model.UserProfile);
                user.IdNumber = random.Next(0, 1000000);
                user.UserName = user.IdNumber.ToString();

                var result = await _userManager.CreateAsync(user, model.Password);

                var roleName = "Member";
                await _userManager.AddToRoleAsync(user, roleName);

                if (result.Succeeded)
                {
                    return RedirectToAction("MembersList", "Home", new { area = "" });
                }
               
            
            return View(model);
        }

        [HttpGet]
        public IActionResult JuryRegistration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> JuryRegistration(RegistrationViewModel model)
        {

            User user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Patronimyc = model.Patronymic,
                BirthDate = model.BirthDate,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Gender = model.Gender,
            };

            user.UserProfile = _imageConverter.ConvertFormFileToByte(model.UserProfile);
            user.IdNumber = random.Next(0, 1000000);
            user.UserName = user.IdNumber.ToString();

            var result = await _userManager.CreateAsync(user, model.Password);

            var roleName = "Moderator";
            await _userManager.AddToRoleAsync(user, roleName);

            if (result.Succeeded)
            {
                return RedirectToAction("JuryList", "Home", new { area = "" });
            }
            return View(model);

        }

    }
}
