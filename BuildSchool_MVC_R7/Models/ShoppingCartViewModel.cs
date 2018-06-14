using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildSchool.MvcSolution.OnlineStore.Models;
using BuildSchool.MvcSolution.OnlineStore.Repository;

namespace BuildSchool_MVC_R7.Models
{
    public class ShoppingCartViewModel
    {
        public User User { get; set; }
        public IEnumerable<ShoppingIconView> ShoppingIconView { get; set; }
        public int Count { get; set; }
        public int Orderid { get; set; }
    }
}