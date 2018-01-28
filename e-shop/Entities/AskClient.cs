using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_shop.Entities
{
    public class AskClient
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int AskClientID { get; set; }

        [Required]
        public DateTime CreateDateTime { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        [Required]
        public string Phone {get; set;}

        public string Theme { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Question { get; set; }
    }
}