using e_shop.Abstract;
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
    public class ProductController : Controller
    {
        private EFProductRepository repository = new EFProductRepository();
        public int PageSize = 4;
        //this.repository = prod
        //public ProductController(IProductRepository productRepository)
        //{
        //    this.repository = productRepository;
        //}

        public ViewResult List(string category, int page = 1)
        {
            ViewBag.IsActiveProduct = "active";
            ProductsListView model = new ProductsListView
            {
                Products = repository.Products.Where(p => category == null || p.Category == category).OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(p => p.Category == category).Count()
                },
                CurrentCategory = category
            };
            //List<Product> l = new List<Product>()
            //{
            //    new Product { Name = "Товар 1", Price = 25},
            //    new Product { Name = "Товар 2", Price = 125},
            //    new Product { Name = "Товар 3", Price = 225}
            //};


            // return View(repository.Products);
            return View(model);

        }
        //// GET: Product
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}