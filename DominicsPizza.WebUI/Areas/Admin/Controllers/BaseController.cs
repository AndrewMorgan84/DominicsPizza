using DominicsPizza.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DominicsPizza.WebUI.Areas.Admin.Controllers
{
    [CustomAuthorise(Role = "Admin")]
    [Area("Admin")]
    public class BaseController : Controller
    {
      
    }
}
