using BuildSchool.MvcSolution.OnlineStore.Repository;
using BuildSchool_MVC_R7.App_Start;
using BuildSchool_MVC_R7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildSchool_MVC_R7.Service
{
    public class OrderService
    {
        public OrderViewModel GetOrders()
        {
            var orderRepository = ContainerManager.Container.GetInstance<OrdersRepository>();
            var orderViewModel = new OrderViewModel()
            {
                Orders = orderRepository.GetAll().ToList()
            };
            return orderViewModel;
        }

        public OrderViewModel GetOrderDetailByOrderID(int orderID)
        {
            var orderDetailRepository = ContainerManager.Container.GetInstance<OrderDetailsRepository>();
            var orderDetailViewModel = new OrderViewModel()
            {
                OrderDetail = orderDetailRepository.GetOrderDetailByOrderID(orderID).ToList()
            };
            return orderDetailViewModel;
        }
    }
}