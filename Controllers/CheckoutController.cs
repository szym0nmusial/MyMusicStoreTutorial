using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMusicStoreTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusicStoreTutorial.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        MusicStoreEntities storeDB;
        const string PromoCode = "FREE";

        public CheckoutController(MusicStoreEntities musicStoreEntities )
        {
            storeDB = musicStoreEntities;
        }
        public IActionResult Index()
        {
            return View();
        }

        //
        // GET: /Checkout/AddressAndPayment
        public ActionResult AddressAndPayment()
        {
            return View();
        }

        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public async Task<IActionResult> AddressAndPayment(IFormCollection values)
        {
            var order = new Order();
            await TryUpdateModelAsync(order);
            try
            {
                if (string.Equals(values["PromoCode"], PromoCode,
                StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }

                else
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;
                    //Save Order
                    storeDB.Orders.Add(order);
                    storeDB.SaveChanges();
                    //Process the order
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);
                    return RedirectToAction("Complete",
                    new { id = order.OrderId });
                }
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = storeDB.Orders.Any(
            o => o.OrderId == id &&
            o.Username == User.Identity.Name);
            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }

    }
}
