using Microsoft.AspNetCore.Mvc;

namespace DominicsPizza.WebUI.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
