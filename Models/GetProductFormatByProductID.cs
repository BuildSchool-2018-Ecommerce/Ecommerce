using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MvcSolution.OnlineStore.Models
{
    public class GetProductFormatByProductID
    {
        public int ProductFormatID { set; get; }
        public string ProductName { set; get; }
        public string Color { set; get; }
        public string Size { set; get; }
        public int StockQuantity {set; get;}
        public decimal UnitPrice { set; get; }
    }
}
