using DominicsPizza.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DominicsPizza.WebUI.Areas.User.Controllers
{
    [CustomAuthorise(Role = "User")]
    [Area("User")]
    public class BaseController : Controller
    {
        
    }
}
