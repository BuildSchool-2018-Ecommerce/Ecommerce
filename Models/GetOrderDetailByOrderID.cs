using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MvcSolution.OnlineStore.Models
{
    public class GetOrderDetailByOrderID
    {
        public int OrderID { set; get; }
        public string Name { set; get; }
        public string ProductName { set; get; }
        public string Status { set; get; }
        public string Color { set; get; }
        public string Size { set; get; }
        public int Quantity { set; get; }
        public decimal UnitPrice { set; get; }
    }
}
