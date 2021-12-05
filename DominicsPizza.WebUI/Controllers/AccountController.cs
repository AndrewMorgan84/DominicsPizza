using DominicsPizza.Entities;
using DominicsPizza.Services.Interfaces;
using DominicsPizza.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DominicsPizza.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthenticationService _authService;
        public AccountController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public IActionResult Login() 
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult SignUp(UserModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };

                bool result = _authService.CreateUser(user, model.Password);
                if (result)
                {
                    RedirectToAction("Login");
                }
            }
            return View();
        }
    }
}
