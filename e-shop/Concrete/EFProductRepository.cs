using e_shop.Abstract;
using e_shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_shop.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Product> Products { get { return context.Products; } }
    }
}