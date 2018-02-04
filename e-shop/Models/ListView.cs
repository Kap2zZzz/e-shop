using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_shop.Models
{
    public class ListView
    {
        //public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public string CurrentFilter { get; set; }
        public int Page { get; set; }
    }
}