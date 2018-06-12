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
    public class ShopService
    {
        public ShopViewModel Shop(string memberid)
        {
            var categoryRepository = ContainerManager.Container.GetInstance<CategoryRepository>();
            var productRepository = ContainerManager.Container.GetInstance<ProductRepository>();
            var memberRepository = ContainerManager.Container.GetInstance<MemberRepository>();
            var shopingrepository = ContainerManager.Container.GetInstance<ShoppingCartRepository>();
            var member = memberRepository.FindById(memberid);
            User user = new User();
            if (member != null)
            {
                user.UserID = memberid;
                user.Username = member.Name;
            }
            var shopViewModel = new ShopViewModel()
            {
                User = user,
                Category = categoryRepository.GetAll(),
                AllProduct = productRepository.AllProduct().ToList(),
                MaxUnitPrice = productRepository.MaxUnitPrice()
            };
            if (member != null)
            {
                shopViewModel.Count = shopingrepository.ShoppingCarts(memberid).Count();
            }
            return shopViewModel;
        }
        public ShopViewModel CategoryShop(int categoryid, string memberid)
        {
            var categoryRepository = ContainerManager.Container.GetInstance<CategoryRepository>();
            var productRepository = ContainerManager.Container.GetInstance<ProductRepository>();
            var memberRepository = ContainerManager.Container.GetInstance<MemberRepository>();
            var shopingrepository = ContainerManager.Container.GetInstance<ShoppingCartRepository>();
            var member = memberRepository.FindById(memberid);
            User user = new User();
            if (member != null)
            {
                user.UserID = memberid;
                user.Username = member.Name;
            }
            var shopViewModel = new ShopViewModel()
            {
                User = user,
                Category = categoryRepository.GetAll(),
                CategoryProduct = productRepository.CategoryProduct(categoryid).ToList(),
                MaxUnitPrice = productRepository.MaxUnitPrice()
            };
            if (member != null)
            {
                shopViewModel.Count = shopingrepository.ShoppingCarts(memberid).Count();
            }
            return shopViewModel;
        }
        public ShopViewModel FindProductByProductID(int productid, string memberid)
        {
            var productRepository = ContainerManager.Container.GetInstance<ProductRepository>();
            var product = productRepository.FindProductByProductID(productid).ToList();
            var memberRepository = ContainerManager.Container.GetInstance<MemberRepository>();
            var shopingrepository = ContainerManager.Container.GetInstance<ShoppingCartRepository>();
            var member = memberRepository.FindById(memberid);
            User user = new User();
            if (member != null)
            {
                user.UserID = memberid;
                user.Username = member.Name;
            }
            var shopViewModel = new ShopViewModel()
            {
                User = user,
                FindProductByProductID = product,
                CategoryProduct = productRepository.CategoryProductNotEqualProductID(product[0].CategoryID, productid).ToList()
            };
            if (member != null)
            {
                shopViewModel.Count = shopingrepository.ShoppingCarts(memberid).Count();
            }
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