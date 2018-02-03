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
    //[RoutePrefix("Catalog")]
    public class ProductController : Controller
    {
        private EFProductRepository repository = new EFProductRepository();
        private EFOrderRepository repositoryOrder = new EFOrderRepository();

        public int PageSize = 6;

        public ActionResult List(string filter, string category, int page = 1)
        {
            ListView model = new ListView { CurrentCategory = category, CurrentFilter = filter };
            ViewBag.IsActiveProduct = "active";
            //ProductsListView model = new ProductsListView { 
            //    Products = new CachedProductsRepository().GetFiltersProducts(page, PageSize, category, filter),
            //    CurrentCategory = category, 
            //    CurrentFilter = filter, 
            //    PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = PageSize, TotalItems = new CachedProductsRepository().GetTotalPages(category, filter) }};
            //ViewBag.category = category;
            //ViewBag.filter = filter;
            //ViewBag.page = page;

            TempData["category"] = category == null ? "" : category;


            //if (Request.IsAjaxRequest())
            //{
            //    return PartialView("AllProductSummary", new { model.CurrentCategory, model.CurrentFilter, model.PagingInfo.CurrentPage });
            //}

            //PageSize = category == null ? 12 : 8;

            //ProductsListView model = new ProductsListView
            //{
            //    //Products = category == null ? repository.Products.OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize) : repository.Products.Where(p => p.Category == category).Where(p => filter == null ? p.Brand != null : p.Brand == filter).OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize),
            //    //Products = category == null ? repository.Products.Skip((page - 1) * PageSize).Take(PageSize) : repository.Products.Where(p => p.Category == category).Where(p => filter == null ? p.Brand != null : p.Brand == filter).Skip((page - 1) * PageSize).Take(PageSize),
            //    Products = new CachedProductsRepository().GetFiltersProducts(page, PageSize, category, filter),
            //    PagingInfo = new PagingInfo
            //    {
            //        CurrentPage = page,
            //        ItemsPerPage = PageSize,
            //        TotalItems = new CachedProductsRepository().GetTotalPages(category, filter)
            //        //TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(p => p.Category == category).Where(p => filter == null ? p.Brand != null : p.Brand == filter).Count()
            //    },
            //    CurrentCategory = category,
            //    CurrentFilter = filter
            //};

            //ProductsListView model = new ProductsListView();
            //model.Products = new CachedProductsRepository().GetFiltersProducts(page, PageSize, category, filter);
            //model.PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = PageSize, TotalItems = new CachedProductsRepository().GetTotalPages(category, filter) };
            //model.CurrentCategory = category;
            //model.CurrentFilter = filter;

            return View(model);

        }

        public PartialViewResult AllProductSummary(string category, string filter, int page = 1)
        {
            //if (plv == null)
            //{
            //    plv = new ProductsListView();
            //}
            ////ViewBag.IsActiveProduct = "active";
            //TempData["category"] = category == null ? "" : category;

            PageSize = category == null ? 12 : 8;

            ProductsListView model = new ProductsListView();
            model.Products = new CachedProductsRepository().GetFiltersProducts(page, PageSize, category, filter);
            model.PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = PageSize, TotalItems = new CachedProductsRepository().GetTotalPages(category, filter) };
            model.CurrentCategory = category;
            model.CurrentFilter = filter;

            return PartialView(model);

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
    }
}