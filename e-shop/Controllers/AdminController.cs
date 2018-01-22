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
    [Authorize]
    public class AdminController : Controller
    {
        private EFProductRepository repository = new EFProductRepository();
        private EFOrderRepository repositoryOrders = new EFOrderRepository();


        //public ActionResult Index()
        //{
        //    return View(repository.Products);
        //}

        public ViewResult Index(string category)
        {
            ViewBag.SelectedCategory = category == null ? "Замовлення" : category;
            AdminViewModel model = new AdminViewModel
            {
                Products = repository.Products,
                Orders = repositoryOrders.Orders,
                CurrentCategory = category
            };

            return View(model);
        }

        public ViewResult Order(int OrderId)
        {
            Order order = repositoryOrders.Orders.FirstOrDefault(o => o.OrderID == OrderId);
            return View(order);
        }

        [HttpPost]
        public ActionResult Order(Order order)
        {
            if (ModelState.IsValid)
            {
                repositoryOrders.SaveOrder(order);
            }
            return RedirectToAction("Index");
        }

        public ViewResult Edit(int productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0}. Дані успішно збережено", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deleteProduct = repository.DeleteProduct(productId);
            if (deleteProduct != null)
            {
                TempData["message"] = string.Format("{0} було успішно видалено!", deleteProduct.Name);
            }
            return RedirectToAction("Index");

        }
    }
}