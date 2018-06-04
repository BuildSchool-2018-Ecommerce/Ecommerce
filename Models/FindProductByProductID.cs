using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MvcSolution.OnlineStore.Models
{
    public class FindProductByProductID
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public decimal Sale { get; set; }
        public int NewProductID { get; set; }
    }
}
