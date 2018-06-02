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
        public ShopViewModel AllShop()
        {
            var productRepository = ContainerManager.Container.GetInstance<ProductRepository>();
            var shopViewModel = new ShopViewModel()
            {
                AllProduct = productRepository.AllProduct().ToList()
            };
            return shopViewModel;
        }
        public ShopViewModel CategoryShop(int categoryid)
        {
            var categoryRepository = ContainerManager.Container.GetInstance<CategoryRepository>();
            var productRepository = ContainerManager.Container.GetInstance<ProductRepository>();
            var shopViewModel = new ShopViewModel()
            {
                Category = categoryRepository.GetAll(),
                CategoryProduct = productRepository.CategoryProduct(categoryid).ToList()
            };
            return shopViewModel;
        }
        public ShopViewModel FindProductByProductID(int productid)
        {
            var productRepository = ContainerManager.Container.GetInstance<ProductRepository>();
            var shopViewModel = new ShopViewModel()
            {
                FindProductByProductID = productRepository.FindProductByProductID(productid).ToList()
            };
            return shopViewModel;
        }
        public ShopViewModel ProductSize(int productid, string color)
        {
            var productRepository = ContainerManager.Container.GetInstance<ProductRepository>();
            var shopViewModel = new ShopViewModel()
            {
                ProductSize = productRepository.ProductSize(productid, color)
            };
            return shopViewModel;
        }
        public ShopViewModel ProductQuantity(int productid, string color, string size)
        {
            var productRepository = ContainerManager.Container.GetInstance<ProductRepository>();
            var shopViewModel = new ShopViewModel()
            {
                ProductQuantity = productRepository.ProductQuantity(productid, color, size)
            };
            return shopViewModel;
        }
    }
}