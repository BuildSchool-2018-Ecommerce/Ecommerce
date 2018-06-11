using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MvcSolution.OnlineStore.Models
{
    public class UpdateShoppingCart
    {
        public List<string> Quantity { get; set; }
        public List<string> ProductFormatID { get; set; }
    }
}
