using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_shop.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [OutputCache(Duration = 86400, Location = System.Web.UI.OutputCacheLocation.Any)]
        public ActionResult PageNotFound()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
    }
}