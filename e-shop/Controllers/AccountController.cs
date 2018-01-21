using e_shop.Concrete;
using e_shop.Infrastructure;
using e_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_shop.Controllers
{
    public class AccountController : Controller
    {
        //private EFProductRepository repository = new EFProductRepository();
        FormAuthProvider authProvider = new FormAuthProvider();
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Увага!, Логін або пароль не вірний");
                    return View();
                }
            }
            else { return View(); }
        }
    }
}