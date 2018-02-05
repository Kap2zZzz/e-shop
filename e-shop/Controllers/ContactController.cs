using e_shop.Concrete;
using e_shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_shop.Controllers
{
    public class ContactController : Controller
    {
        private EFAskClientRepository repositoryAsk = new EFAskClientRepository();

        // GET: Contact
        [OutputCache(Duration = 86400, Location = System.Web.UI.OutputCacheLocation.Any)]
        public ActionResult Contact()
        {
            ViewBag.IsActiveContact = "active";
            ViewBag.keywords = "Адреса, ТВК, ПІВДЕННИЙ, ТЦ, ЕКСПО, БУД, 35, Графік, Робота, Телефон, Карта, Маршрут, Як, Доїхати";
            ViewBag.description = "Електротовари для дому за найнижчими цінами. Адреса: м. Львів, вул. Щирецька 36 (ТВК ПІВДЕННИЙ, ТЦ ЕКСПО БУД №35). Графік роботи: 9:00-18:00. Понеділок - вихідний! Телефон: (093)-677-93-35";
            return View();
        }

        [HttpPost]
        public ActionResult Contact(AskClient askClient)
        {
            if (ModelState.IsValid)
            {
                repositoryAsk.SaveAsk(askClient);
                TempData["valid"] = "1";
                TempData["message"] = "Ваше повідомлення успішно відправлено. Очікуйте на дзвінок менеджера. Дякуюємо що скористались нашим магазином.";
                return RedirectToAction("Contact");
            }
            else
            {
                ViewBag.IsActiveContact = "active";
                TempData["valid"] = "0";
                TempData["message"] = "Увага!, Для відправки повідомлення, прохання заповнити усі необхідні поля.";
                return View();
            }
        }
    }
}