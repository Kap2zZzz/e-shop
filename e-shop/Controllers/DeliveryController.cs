using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_shop.Controllers
{
    public class DeliveryController : Controller
    {
        // GET: Delivery
        [OutputCache(Duration = 86400, Location = System.Web.UI.OutputCacheLocation.Any)]
        public ActionResult Delivery()
        {
            @ViewBag.IsActiveDelivery = "active";
            return View();
        }
    }
}