using DominicsPizza.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominicsPizza.WebUI.Areas.Admin.Controllers
{
    public class ItemController : BaseController
    {
        ICatalogService _catalogService;

        public ItemController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }
        public IActionResult Index()
        {
            var data = _catalogService.GetItems();
            return View(data);
        }
    }
}
