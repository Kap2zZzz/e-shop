using e_shop.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_shop.Controllers
{
    public class HomeController : Controller
    {
        //[OutputCache(Duration = 86400, Location = System.Web.UI.OutputCacheLocation.Any)]
        public ActionResult Index()
        {
            ViewBag.IsActiveHome = "active";
            ViewBag.keywords = Helper.GetKeywords(null);
            ViewBag.description = Helper.GetKeywords(null);
            return View();
        }
    }
}