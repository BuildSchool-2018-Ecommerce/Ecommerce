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
    public class ProductService
    {
        public ProductViewModel GetProducts()
        {
            var productRepository = ContainerManager.Container.GetInstance<ProductRepository>();
            var productViewModel = new ProductViewModel()
            {
                Products = productRepository.GetAll().ToList()
            };
            return productViewModel;
        }

        public ProductFormatViewModel GetProductFormatByProductID(int ProductID)
        {
            var productFormatRepository = ContainerManager.Container.GetInstance<ProductRepository>();
            var productFormatViewModel = new ProductFormatViewModel()
            {
                ProductFormat = productFormatRepository.GetProductFormatByProductID(ProductID).ToList()
            };
            return productFormatViewModel;
        }

        public ProductViewModel GetProductDetailByProductID(int ProductID)
        {
            var productRepository = ContainerManager.Container.GetInstance<ProductRepository>();
            var productViewModel = new ProductViewModel()
            {
                Product = productRepository.FindById(ProductID)
            };
            return productViewModel;
        }

        public ProductFormatViewModel GetProductDetailByProductFormatID(int ProductFormatID)
        {
            var productFormatRepository = ContainerManager.Container.GetInstance<ProductFormatRepository>();
            var productFormatViewModel = new ProductFormatViewModel()
            {
                ProductFormat = productFormatRepository.GetProductFormatByProductFormatID(ProductFormatID)
            };
            return productFormatViewModel;
        }

        public ProductViewModel GetProductsByCategoryName(string CategoryName)
        {
            var productRepository = ContainerManager.Container.GetInstance<ProductRepository>();
            var productViewModel = new ProductViewModel()
            {
                Products = productRepository.GetProductsByCategoryName(CategoryName)
            };
            return productViewModel;
        }

        public ProductViewModel GetProductByProductName(string ProductName)
        {
            var productRepository = ContainerManager.Container.GetInstance<ProductRepository>();
            var productViewModel = new ProductViewModel()
            {
                Products = productRepository.FindByProductName(ProductName)
            };
            return productViewModel;
        }

        public IEnumerable<AllProduct> salesProducts()
        {
            var productrepository = ContainerManager.Container.GetInstance<ProductRepository>();
            return productrepository.AllProduct();
        }
    }
}