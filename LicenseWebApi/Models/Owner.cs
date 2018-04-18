using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LicenseWebApi.Models
{
    public class Owner
    {
        [Key]
        
        public int Id { get; set; }
        [Required]
        public string first { get; set; }
        [Required]
        public string last { get; set; }
        public string company { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string coutry { get; set; }
        public string phone { get; set; }
    }
}