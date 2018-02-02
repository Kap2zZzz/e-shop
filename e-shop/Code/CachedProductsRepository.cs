using e_shop.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using e_shop.Entities;

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

    }
}