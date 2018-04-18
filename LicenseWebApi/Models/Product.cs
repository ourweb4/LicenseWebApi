using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LicenseWebApi.Models
{
    public class Product
    {
        [Key]

        public int Id { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string name { get; set; }

        [Display(Name ="Current Version")]
        public string currversion { get; set; }
        public int owner_id { get; set; }

    }
}