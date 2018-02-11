using e_shop.Code;
using e_shop.Concrete;
using e_shop.Entities;
using e_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_shop.Controllers
{
    public class CartController : Controller
    {
        private EFProductRepository repository = new EFProductRepository();
        private EFOrderRepository repositoryOrder = new EFOrderRepository();


        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }

        [HttpPost]
        public ViewResult Index(Cart cart, FormCollection fm, string returnUrl)
        {
            string[] prodId = fm.GetValues("ProductId");
            string[] q = fm.GetValues("Quantity");
            int i=0;

            foreach (var a in cart.Lines.Where(l=>l.Product.ProductID == Convert.ToInt32(prodId[0])))
            {
                a.Quantity = Convert.ToInt32(q[0]);
                i++;
            }
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        //[NonAction]
        public ActionResult Checkout()
        {
            Cart cart = new Cart();

            if (HttpContext.Session != null)
            {
                cart = (Cart)HttpContext.Session["Cart"];
                if (cart == null) { cart = new Cart(); }
            }

            if (cart.Lines.Count() == 0)
            {
                return RedirectToAction("Index");
            }

            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                TempData["message"] = "Увага!, Ваш кошик порожній.";
                Response.StatusCode = 404;
                Response.TrySkipIisCustomErrors = true;
                return View("PageNotFound");
            }

            if (ModelState.IsValid)
            {
                //Тут буде відправка на пошту + запис в базу
                Order order = new Order();
                order.OrderLines = new List<OrderLine>();
                order.UserName = shippingDetails.Name;
                order.UserPhone = shippingDetails.Phone;
                order.City = shippingDetails.City;
                order.DeliveryAddress = shippingDetails.Address;
                order.Status = Helper.StatusOrder()[0].ToString();
                foreach (var c in cart.Lines)
                {
                    OrderLine orderLine = new OrderLine();
                    orderLine.Name = c.Product.Name;
                    orderLine.Price = c.Product.Price;
                    orderLine.Quantity = c.Quantity;
                    order.OrderLines.Add(orderLine);
                }

                repositoryOrder.SaveOrder(order); //Збереження до БД
                Mail.Send(order); //Відправка на пошту
                
                cart.Clear();

                return View("Completed", order);
            }
            else 
            {
                TempData["message"] = "Увага!, Для оформлення замовлення, будь-ласка заповніть усі необхідні поля.";
                return View(shippingDetails);
            }
        }
    }
}