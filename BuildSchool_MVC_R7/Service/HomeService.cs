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
        public IEnumerable<ProductFormat> Home()
        {
            var productrepository = new ProductFormatRepository();
            var product = productrepository.GetAll();
            return product;
        }
    }
}