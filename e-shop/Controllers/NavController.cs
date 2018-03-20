using e_shop.Concrete;
using e_shop.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_shop.Controllers
{
    public class NavController : Controller
    {
        public PartialViewResult Menu(string category = null, bool horizontalLayout = false)
        {
            ViewBag.SelectedCategory = category == null ? "Усі товари" : category;
            string viewName = horizontalLayout ? "MenuHorizontal" : "Menu";
            return PartialView(viewName, new CachedProductsRepository().GetMenu());
        }
    }
}