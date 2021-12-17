using DominicsPizza.Repositories.Models;
using DominicsPizza.WebUI.Helpers;
using DominicsPizza.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DominicsPizza.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            PaymentModel payment = new PaymentModel();
            CartModel cart = TempData.Peek<CartModel>("Cart");

            if(cart != null)
            {
                payment.Cart = cart;
            }

            payment.GrandTotal = Math.Round(cart.GrandTotal);
            payment.Currency = "GBP";
            string items = "";
            foreach (var item in cart.Items)
            {
                items += item.Name + ",";
            }
            payment.Description = items;

            return View(payment);
        }
    }
}
