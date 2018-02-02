using e_shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_shop.Code
{
    public static class Helper
    {
        public static List<string> Category()
        {
            List<string> c = new List<string> 
            { "Тепла підлога", 
              "Терморегулятори", 
              "Кабель", 
              "Щитки, бокси (метал, пластик)", 
              "LED освітлення", 
              "Автоматика", 
              "Інше 2" 
            };
            c.Sort();
            return c;
        }

        public static List<string> StatusOrder()
        {
            List<string> so = new List<string> { "Нове замовлення", "В роботі", "Виконано", "Відмовлено" };
            return so;
        }

        public static int getTotalItems(string category, string filter, IEnumerable<Product> products)
        {
            int k = 0;

            if (category == null || category == string.Empty)
            {
                k = products.Count();
            }
            else if (filter == null || filter == string.Empty)
            {
                k = products.Where(p => p.Category == category).Count();
            }
            else
            {
                k = products.Where(p => p.Category == category && p.Brand == filter).Count();
            }
            //        TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(p => p.Category == category).Where(p => filter == null ? p.Brand != null : p.Brand == filter).Count()
            return k;
        }

        public static IEnumerable<Product> getTotalProducts(int page, int pageSize, string category, string filter, IEnumerable<Product> products)
        {
            IEnumerable<Product> countProduct;

            if (category == null || category == string.Empty)
            {
                countProduct = products.Skip((page - 1) * pageSize).Take(pageSize);
            }
            else if (filter == null || filter == string.Empty)
            {
                countProduct = products.Where(p => p.Category == category).Skip((page - 1) * pageSize).Take(pageSize);
            }
            else
            {
                countProduct = products.Where(p => p.Category == category && p.Brand == filter).Skip((page - 1) * pageSize).Take(pageSize);
            }
            return countProduct;
        }
    }
}