using e_shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_shop.Models
{
    public class ProductsListView
    {
        public IEnumerable<Product> Products;
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}