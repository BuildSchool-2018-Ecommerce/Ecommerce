using BuildSchool.MvcSolution.OnlineStore.Models;
using BuildSchool.MvcSolution.OnlineStore.Repository;
using BuildSchool_MVC_R7.App_Start;
using BuildSchool_MVC_R7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildSchool_MVC_R7.Service
{
    public class HomeService
    {
        public HomeViewModel Home()
        {
            var productRepository =  ContainerManager.Container.GetInstance<ProductRepository>();
            var homeViewModel = new HomeViewModel()
            {
                Products = productRepository.GetAll()
            };
            return homeViewModel;
        }
    }
}