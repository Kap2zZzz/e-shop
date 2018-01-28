using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_shop.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Будь ласка заповніть поле: Прізвище Ім'я По батькові")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Будь ласка заповніть поле: Контактний телефон")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Будь ласка заповніть поле: Місто")]
        public string City { get; set; }

        [Required(ErrorMessage = "Будь ласка заповніть поле: Адреса доставки")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
    }
}