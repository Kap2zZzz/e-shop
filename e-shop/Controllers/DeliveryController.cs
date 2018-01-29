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
        public ActionResult Delivery()
        {
            @ViewBag.IsActiveDelivery = "active";
            return View();
        }
    }
}