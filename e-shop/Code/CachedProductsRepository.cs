using e_shop.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using e_shop.Entities;
using e_shop.Models;

namespace e_shop.Code
{
    public class CachedProductsRepository: EFProductRepository
    {
        private static readonly object CacheLockObject = new object();

        public override IEnumerable<Product> GetFiltersProducts(int page, int pageSize, string category, string filter)
        {
            string cacheKey = "Select-" + page + "-" + category + "-" + filter;
            var result = HttpRuntime.Cache[cacheKey] as IEnumerable<Product>;
            if (result == null)
            {
                lock(CacheLockObject)
                {
                    result = HttpRuntime.Cache[cacheKey] as IEnumerable<Product>;
                    if (result == null)
                    {
                        result = base.GetFiltersProducts(page, pageSize, category, filter);
                        HttpRuntime.Cache.Insert(cacheKey, result, null, DateTime.Now.AddHours(1), TimeSpan.Zero);
                    }
                }
            }
            return result;
        }

        public override int GetTotalPages(string category, string filter)
        {
            string cacheKey = "TotalItems-" + category + "-" + filter;
            var result = HttpRuntime.Cache[cacheKey];
            if (result == null)
            {
                lock (CacheLockObject)
                {
                    result = HttpRuntime.Cache[cacheKey];
                    if (result == null)
                    {
                        result = base.GetTotalPages(category, filter);
                        HttpRuntime.Cache.Insert(cacheKey, result, null, DateTime.Now.AddHours(1), TimeSpan.Zero);
                    }
                }
            }
            return Convert.ToInt16(result);
        }

        //public List<string> GetProductsBrand(string category)
        //{
        //    string cacheKey = "ProductsBrand-" + category;
        //    var result = HttpRuntime.Cache[cacheKey] as List<string>;
        //    if (result == null)
        //    {
        //        lock (CacheLockObject)
        //        {
        //            result = HttpRuntime.Cache[cacheKey] as List<string>;
        //            if (result == null)
        //            {
        //                result = new List<string>();
        //                var _tempProducts = Products.Where(p => p.Category == category).GroupBy(x => x.Brand);

        //                foreach (var a in _tempProducts)
        //                {
        //                    result.Add(a.Key);
        //                }

        //                HttpRuntime.Cache.Insert(cacheKey, result, null, DateTime.Now.AddHours(12), TimeSpan.Zero);
        //            }
        //        }
        //    }
        //    return result;
        //}

        public List<MenuView> GetMenu()
        {
            string cacheKey = "Menu";
            var result = HttpRuntime.Cache[cacheKey] as List<MenuView>;
            if (result == null)
            {
                lock (CacheLockObject)
                {
                    result = HttpRuntime.Cache[cacheKey] as List<MenuView>;
                    if (result == null)
                    {
                        result = Helper.GetMenu();
                        HttpRuntime.Cache.Insert(cacheKey, result, null, DateTime.Now.AddHours(1), TimeSpan.Zero);
                    }
                }
            }
            return result;          
        }
    }
}