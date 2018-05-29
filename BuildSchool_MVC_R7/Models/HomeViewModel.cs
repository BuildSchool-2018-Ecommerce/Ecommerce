using BuildSchool.MvcSolution.OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildSchool_MVC_R7.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductFormat> ProductFormats { get; set; }
        public IEnumerable<NewProduct> NewProduct { get; set; }
        public IEnumerable<SalesProduct> SalesProduct { get; set; }
        public IEnumerable<Top8Product> Top8Product { get; set; }
    }
}