using e_shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_shop.Models
{
    public class AdminViewModel
    {
        public IEnumerable<Product> Products;
        public IEnumerable<Order> Orders;
        public string CurrentCategory { get; set; }
    }
}