using BuildSchool.MvcSolution.OnlineStore.Repository;
using BuildSchool_MVC_R7.App_Start;
using BuildSchool_MVC_R7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildSchool_MVC_R7.Service
{
    public class ShopService
    {
        public ShopViewModel Shop()
        {
            var categoryRepository = ContainerManager.Container.GetInstance<CategoryRepository>();
            var productRepository = ContainerManager.Container.GetInstance<ProductRepository>();
            var shopViewModel = new ShopViewModel()
            {
                Category = categoryRepository.GetAll(),
                AllProduct = productRepository.AllProduct().ToList()
            };
            return shopViewModel;
        }
    }
}