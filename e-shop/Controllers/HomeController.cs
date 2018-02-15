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
        //
        // GET: /Home/
        //[OutputCache(Duration = 86400, Location = System.Web.UI.OutputCacheLocation.Any)]
        public ActionResult Index()
        {
            ViewBag.IsActiveHome = "active";
            //ViewBag.keywords = "Купити, Електротовари, Львів, Кабель, Тепла підлога, Терморегулятори, Щитки, Бокси, LED, Освітлення, Автоматика, Діодна, Стрічка, Відсікачі, Дешево, Ціна";
            //ViewBag.description = "Електротовари для дому за найнижчими цінами. Реалізовуємо продукцію таких відомих брендів як: GRAYHOT, IN - TERM, LED Original, FENIX, Hemstedt, Mutlusan, VIP кабель, Schneider, HOROZ";
            ViewBag.keywords = Helper.GetKeywords(null);
            ViewBag.description = Helper.GetKeywords(null);

            return View();
        }
    }
}