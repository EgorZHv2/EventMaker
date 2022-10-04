using EventMaker.Areas.Account.Models;
using EventMaker.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace EventMaker.Areas.Account.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AuthController> _logger;
        public AuthController(UserManager<User> userManager = null,
                              SignInManager<User> signInManager = null,
                              ILogger<AuthController> logger = null)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
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

                if (!string.IsNullOrEmpty(loginmodel.ReturnUrl) && Url.IsLocalUrl(loginmodel.ReturnUrl))
                {
                   
                    return Redirect(loginmodel.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("UserWindow", "Home", new { area = "" });
                }
            }


            return View(loginmodel);

        }
    }
}
