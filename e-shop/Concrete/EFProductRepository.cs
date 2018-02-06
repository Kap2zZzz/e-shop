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

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbProduct = context.Products.Find(product.ProductID);
                if (dbProduct != null)
                {
                    dbProduct.Brand = product.Brand;
                    dbProduct.Name = product.Name;
                    dbProduct.Description = product.Description;
                    dbProduct.Price = product.Price;
                    dbProduct.Category = product.Category;
                    dbProduct.ImageData = product.ImageData;
                    dbProduct.ImageMimeType = product.ImageMimeType;
                    dbProduct.ImageName = product.ImageName;
                }
            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {
            Product dbProduct = context.Products.Find(productID);
            if (dbProduct != null)
            {
                context.Products.Remove(dbProduct);
                context.SaveChanges();
            }
            return dbProduct;
        }

        public virtual IEnumerable<Product> GetFiltersProducts(int page, int pageSize, string category, string filter)
        {
            return category == null ? Products.Skip((page - 1) * pageSize).Take(pageSize) : 
                Products.Where(p => p.Category == category)
                .Where(p => filter == null ? p.Brand != null : p.Brand == filter)
                .Skip((page - 1) * pageSize).Take(pageSize);
        }

        public virtual int GetTotalPages(string category, string filter)
        {
            return category == null ? Products.Count() : Products.Where(p => p.Category == category).Where(p => filter == null ? p.Brand != null : p.Brand == filter).Count();
        }

    }
}