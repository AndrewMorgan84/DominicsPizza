using Microsoft.AspNetCore.Mvc;

namespace DominicsPizza.WebUI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
