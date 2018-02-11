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
        //[OutputCache(Duration = 86400, Location = System.Web.UI.OutputCacheLocation.Any)]
        public ActionResult About()
        {
            ViewBag.IsActiveAbout = "active";
            ViewBag.keywords = "Монтаж, Тепла підлога, Мат, Кабель, Плівка, Електропроводка, Стабілізатори, Напруга, Щити, Автомати, Розрахунки, Консультація, Дешево, Ціна";
            ViewBag.description = "Електротовари для дому за найнижчими цінами. Надаємо послуги монтажу: теплої підлоги (мат, кабель, плівка), електропроводки (розведення мережі, встановлення стабілізаторів напруги, заміна автоматів, монтаж щитів, тощо), Виклик фвхівця для замірів, оптимальні розрахунки, консультація, помірні ціни.";

            return View();
        }
    }
}