using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_shop.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }

        [Display(Name = "Назва бренду")]
        [Required(ErrorMessage = "Увага!, поле [Бренд] не заповнено!")]
        public string Brand {get; set;}

        [Display(Name = "Назва товару")]
        [Required(ErrorMessage = "Увага!, поле [Назва товару] не заповнено!")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Опис товару")]
        [Required(ErrorMessage = "Увага!, поле [Опис товару] не заповнено!")]
        public string Description { get; set; }

        [Display(Name = "Ціна")]
        [Required(ErrorMessage = "Увага!, поле [Ціна] не заповнено!")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Увага!, поле [Ціна] повинно бути більшим 0!")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Категорія")]
        [Required(ErrorMessage = "Увага!, поле [Категорія] не заповнено!")]
        public string Category { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}