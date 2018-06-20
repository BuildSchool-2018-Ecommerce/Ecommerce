
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BuildSchool.MvcSolution.OnlineStore.Models
{
    public class SearchProduct
    {
        public int ProductID { get; set; }
        public string Image { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Sale { get; set; }
        public decimal Price { get; set; }
    }
}