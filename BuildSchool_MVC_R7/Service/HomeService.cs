using BuildSchool.MvcSolution.OnlineStore.Models;
using BuildSchool.MvcSolution.OnlineStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildSchool_MVC_R7.Service
{
    public class HomeService
    {
        public IEnumerable<Product> Home()
        {
            var productrepository = new ProductRepository();
            var product = productrepository.GetAll();
            return product;
        }
    }
}