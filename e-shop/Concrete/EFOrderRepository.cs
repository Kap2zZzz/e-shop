using e_shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_shop.Concrete
{
    public class EFOrderRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Order> Orders { get { return context.Orders; } }

        public void SaveOrder(Order order)
        {
            if (order.OrderID == 0)
            {
                order.DateCreateOrder = System.DateTime.Now;
                order.Suma = order.OrderLines.Sum(x => x.ComputeTotalValue);
                context.Orders.Add(order);
            }
            else
            {
                Order dbOrder = context.Orders.Find(order.OrderID);
                if (dbOrder != null)
                {
                    dbOrder.Status = order.Status;
                }
            }
            context.SaveChanges();
        }

        public Order DeleteOrder(int orderId)
        {
            Order dbOrder = context.Orders.Find(orderId);
            if (dbOrder != null)
            {
                context.Orders.Remove(dbOrder);
                context.SaveChanges();
            }
            return dbOrder;
        }
    }
}