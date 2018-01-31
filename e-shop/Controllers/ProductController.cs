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
    //[RoutePrefix("Catalog")]
    public class ProductController : Controller
    {
        private EFProductRepository repository = new EFProductRepository();
        private EFOrderRepository repositoryOrder = new EFOrderRepository();

        public int PageSize = 5;

        public ViewResult List(string filter, string category, int page = 1)
        {
            ViewBag.IsActiveProduct = "active";
            TempData["category"] = category == null ? "" : category;
            ProductsListView model = new ProductsListView
            {
                Products = category == null ? repository.Products.OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize) : repository.Products.Where(p => p.Category == category).Where(p => filter == null ? p.Brand != null : p.Brand == filter).OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(p => p.Category == category).Where(p => filter == null ? p.Brand != null : p.Brand == filter).Count()
                },
                CurrentCategory = category,
                CurrentFilter = filter
            };
            return View(model);

        }

        [OutputCache(Duration = 1200, Location = System.Web.UI.OutputCacheLocation.Downstream)]
        public FileContentResult GetImage(int productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                return File(product.ImageData, product.ImageMimeType);
            }
            else return null;
        }
    }
}