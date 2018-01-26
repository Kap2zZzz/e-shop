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
        // GET: Nav
        private EFProductRepository repository = new EFProductRepository();

        public PartialViewResult Menu(string category = null, bool horizontalLayout = false)
        {
            ViewBag.SelectedCategory = category == null ? "Усі товари" : category;
            //IEnumerable<string> categories = repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x);
            IEnumerable<string> categories = Helper.Category();
            string viewName = horizontalLayout ? "MenuHorizontal" : "Menu";
            return PartialView(viewName, categories);
        }
    }
}