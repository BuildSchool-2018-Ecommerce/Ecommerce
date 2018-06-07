using BuildSchool.MvcSolution.OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildSchool_MVC_R7.Models
{
    public class OrderViewModel
    {
        public IEnumerable<Orders> Orders { set; get; }
        public IEnumerable<GetOrderDetailByOrderID> OrderDetail { set; get; }
    }
}