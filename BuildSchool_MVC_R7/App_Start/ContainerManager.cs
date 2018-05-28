using BuildSchool.MvcSolution.OnlineStore.Repository;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildSchool_MVC_R7.App_Start
{
    public class ContainerManager
    {
        private static Container _container;
        public static Container Container
        {
            get
            {
                if (_container == null)
                {
                    CreateContainer();
                }
                return _container;
            }

        }

        private static void CreateContainer()
        {
            _container = new Container();
            _container.Register<ProductRepository, ProductRepository>();
            _container.Register<ProductFormatRepository, ProductFormatRepository>();
            _container.Register<EmployeesRepository, EmployeesRepository>();
            _container.Register<MemberRepository, MemberRepository>();
            _container.Register<CategoryRepository, CategoryRepository>();
            _container.Register<ActivityRepository, ActivityRepository>();
            _container.Register<ImageRepository, ImageRepository>();
            _container.Register<OrderDetailsRepository, OrderDetailsRepository>();
            _container.Register<OrdersRepository, OrdersRepository>();
            _container.Register<SalesRepository, SalesRepository>();
            _container.Register<ShoppingCartRepository, ShoppingCartRepository>();
          
        }
    }
}