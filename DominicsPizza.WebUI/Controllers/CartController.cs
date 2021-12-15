using DominicsPizza.Repositories.Models;
using DominicsPizza.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DominicsPizza.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        Guid CartId
        {
            get
            {
                Guid Id;
                string CId = Request.Cookies["CId"];
                if (string.IsNullOrEmpty(CId))
                {
                    Id = Guid.NewGuid();
                    Response.Cookies.Append("CId", Id.ToString());
                }
                else
                {
                    Id = Guid.Parse(CId);
                }
                return Id;
            }
        }

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            CartModel cart = _cartService.GetCartDetails(CartId);
            return View(cart);
        }
    }
}
