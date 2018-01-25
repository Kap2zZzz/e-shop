using e_shop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace e_shop.Concrete
{
    public class EFDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }

        public DbSet<AskClient> AskClients { get; set; }

    }
}