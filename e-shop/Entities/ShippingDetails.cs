using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_shop.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Будь ласка заповніть поле Ім'я")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Будь ласка заповніть поле Телефон")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Будь ласка заповніть поле Місто")]
        public string City { get; set; }

        [Required(ErrorMessage = "Будь ласка заповніть поле Адреса")]
        public string Address { get; set; }
    }
}