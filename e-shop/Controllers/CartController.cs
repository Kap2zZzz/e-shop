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

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Увага!, Ваш кошик пустий");
            }

            if (ModelState.IsValid)
            {
                //Тут буде відправка на пошту + запис в базу
                Order order = new Order();
                order.OrderLines = new List<OrderLine>();
                order.UserName = shippingDetails.Name;
                order.UserPhone = shippingDetails.Phone;
                foreach (var c in cart.Lines)
                {
                    OrderLine orderLine = new OrderLine();
                    orderLine.Name = c.Product.Name;
                    orderLine.Price = c.Product.Price;
                    orderLine.Quantity = c.Quantity;
                    order.OrderLines.Add(orderLine);
                }

                repositoryOrder.SaveOrder(order);
                
                cart.Clear();

                return View("Completed", order);
            }
            else 
            {
                return View(shippingDetails);
            }
        }
    }
}