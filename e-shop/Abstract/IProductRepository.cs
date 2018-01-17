using e_shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shop.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; } 
    }
}
