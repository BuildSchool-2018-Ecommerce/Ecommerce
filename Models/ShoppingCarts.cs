using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MvcSolution.OnlineStore.Models
{
    public class ShoppingCarts
    {
        public int ID { get; set; }
        public string MemberID { get; set; }
        public int ProductFormaatID { get; set; }
        public int Quantity { get; set; }
    }
}
