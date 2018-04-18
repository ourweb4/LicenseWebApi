using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LicenseWebApi.Models;

 
namespace LicenseWebApi.ViewModels
{
    public class LicenseVM
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public License license { get; set; }
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        public IEnumerable<Product> products{ get; set; }

        public string productname()
        {
            Product product = db.Products.SingleOrDefault(p => p.Id == license.product_id);
            return product.name;

        }


    }
}