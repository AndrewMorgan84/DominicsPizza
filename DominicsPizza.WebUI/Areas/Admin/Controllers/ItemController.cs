using DominicsPizza.Entities;
using DominicsPizza.Services.Interfaces;
using DominicsPizza.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DominicsPizza.WebUI.Areas.Admin.Controllers
{
    public class ItemController : BaseController
    {
        ICatalogService _catalogService;
        IFileHelper _fileHelper;

        public ItemController(ICatalogService catalogService, IFileHelper fileHelper)
        {
            _catalogService = catalogService;
            _fileHelper = fileHelper;
        }
        public IActionResult Index()
        {
            var data = _catalogService.GetItems();
            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _catalogService.GetCategories();
            ViewBag.ItemTypes = _catalogService.GetItemTypes();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ItemModel model)
        {
            try
            {
                model.ImageUrl = _fileHelper.UploadFile(model.File);
                Item data = new Item()
                {
                    Name = model.Name,
                    UnitPrice = model.UnitPrice,
                    CategoryId = model.CategoryId,
                    ItemTypeId = model.ItemTypeId,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl
                };

                _catalogService.AddItem(data);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

            }
            ViewBag.Categories = _catalogService.GetCategories();
            ViewBag.ItemTypes = _catalogService.GetItemTypes();
            return View();
        }
    }
}
