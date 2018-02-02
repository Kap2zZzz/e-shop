using e_shop.Concrete;
using e_shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_shop.Controllers
{
    public class AboutController : Controller
    {

        // GET: About
        [OutputCache(Duration = 86400, Location = System.Web.UI.OutputCacheLocation.Any)]
        public ActionResult About()
        {
            ViewBag.IsActiveAbout = "active";
            return View();
        }
    }
}