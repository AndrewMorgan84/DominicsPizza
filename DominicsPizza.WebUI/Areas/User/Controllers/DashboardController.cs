using Microsoft.AspNetCore.Mvc;

namespace DominicsPizza.WebUI.Areas.User.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
