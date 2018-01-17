using e_shop.Abstract;
using e_shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_shop.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        //public ProductController(IProductRepository productRepository)
        //{
        //    this.repository = productRepository;
        //}

        public ViewResult List()
        {
            List<Product> l = new List<Product>()
            {
                new Product { Name = "Товар 1", Price = 25},
                new Product { Name = "Товар 2", Price = 125},
                new Product { Name = "Товар 3", Price = 225}
            };

            // return View(repository.Products);
            return View(l);

        }
        //// GET: Product
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}