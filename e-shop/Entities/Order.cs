using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_shop.Entities
{
    public class Order
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int OrderID { get; set; }

        public DateTime DateCreateOrder { get; set; }

        public string UserName { get; set; }

        public string UserPhone { get; set; }

        public string Status { get; set; }

        public decimal Suma { get; set; }

        public string City { get; set; }

        public string DeliveryAddress { get; set; }

        public virtual List<OrderLine> OrderLines { get; set; }

    }

    public class OrderLine
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int OrderLineID { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        private decimal computeTotalValue;
        public decimal ComputeTotalValue
        {
            get { return this.computeTotalValue = Price * Quantity; }
            set { this.computeTotalValue = value; }
        }

        public virtual Order RelOrder { get; set; }
    }
}