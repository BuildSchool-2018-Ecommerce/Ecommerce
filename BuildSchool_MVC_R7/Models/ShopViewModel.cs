using BuildSchool.MvcSolution.OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildSchool_MVC_R7.Models
{
    public class ShopViewModel
    {
        public IEnumerable<Category> Category { get; set; }
        public List<AllProduct> AllProduct { get; set; }
        public List<CategoryProduct> CategoryProduct { get; set; }
        public List<FindProductByProductID> FindProductByProductID { get; set; }
        public IEnumerable<ProductSizeAndQuantity> ProductSize { get; set; }
        public ProductSizeAndQuantity ProductQuantity { get; set; }
    }
}