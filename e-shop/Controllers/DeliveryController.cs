using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_shop.Controllers
{
    public class DeliveryController : Controller
    {
        //[OutputCache(Duration = 86400, Location = System.Web.UI.OutputCacheLocation.Any)]
        public ActionResult Delivery()
        {
            @ViewBag.IsActiveDelivery = "active";
            ViewBag.keywords = "Доставка, Львів, Безкоштовно, Готівка, Електротовари, Тепла підлога, Кабель, Стабілізатори, Напруга, Щити, Автомати, Дешево, Ціна";
            ViewBag.description = "Електротовари для дому за найнижчими цінами. Доставка Нова пошта, Інтайм, Міст Експрес, Автолюкс, Самовивіз із магазину, по Львову - БЕЗКОШТОВНО! Надаємо знижки від 2% до 10%, Гарантія повернення. Деталі за телефоном: (093)-677-93-35";
            return View();
        }
    }
}