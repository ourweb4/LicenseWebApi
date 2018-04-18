using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LicenseWebApi.Models;

namespace LicenseWebApi.ViewModels
{
    public class ProductVM
    {
        public Product product { get; set; }
        public IEnumerable<Owner> owner { get; set; }
    }
}