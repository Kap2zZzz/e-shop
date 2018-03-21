using e_shop.Abstract;
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
    public class ProductController : Controller
    {
        private EFProductRepository repository = new EFProductRepository();

        public ActionResult Index(string filter, string category, int page = 1)
        {
            int PageSize = 12;
            ViewBag.keywords = string.Format(Helper.GetKeywords(category), string.Empty);
            ViewBag.description = string.Format(Helper.GetKeywords(category), string.Empty);

            ViewBag.IsActiveProduct = "active";
            ViewBag.Category = category == null ? "Електротовари" : category;
            ViewBag.Filter = filter == null ? "Уся продукція" : filter;

            ProductsListView model = new ProductsListView
            {
                Products = new CachedProductsRepository().GetFiltersProducts(page, PageSize, category, filter),
                PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = PageSize, TotalItems = new CachedProductsRepository().GetTotalPages(category, filter) },
                CurrentCategory = category,
                CurrentFilter = filter
            };        

            TempData["category"] = category == null ? "" : category;
     
            return View(model);
        }     

        [OutputCache(Duration = 1200, Location = System.Web.UI.OutputCacheLocation.Any)]
        public FileContentResult GetImage(int productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                return File(product.ImageData, product.ImageMimeType);
            }
            else return null;
        }

        public ActionResult Details(string category, int id)
        {
            ViewBag.IsActiveProduct = "active";
            //ViewBag.returnUrl = Request.Url.PathAndQuery;
            var model = repository.Products.FirstOrDefault(p => p.ProductID == id);
            ViewBag.keywords = string.Format(Helper.GetKeywords(model.Category), " " + model.Name + ",");
            ViewBag.description = string.Format(Helper.GetKeywords(model.Category), " " + model.Name + ",");
            TempData["category"] = model.Category == null ? "" : model.Category;
            return View(model);
        }
    }
}