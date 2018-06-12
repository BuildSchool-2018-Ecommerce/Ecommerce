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
        public HomeViewModel Home(string memberid)
        {
            var productRepository =  ContainerManager.Container.GetInstance<ProductRepository>();
            var memberRepository = ContainerManager.Container.GetInstance<MemberRepository>();
            var shopingrepository = ContainerManager.Container.GetInstance<ShoppingCartRepository>();
            var member = memberRepository.FindById(memberid);
            User user = new User();
            if(member != null)
            {
                user.UserID = memberid;
                user.Username = member.Name;
            }
            var homeViewModel = new HomeViewModel()
            {
                User = user,
                NewProduct = productRepository.NewProduct(),
                SalesProduct = productRepository.SalesProduct(),
                Top8Product = productRepository.Top8Product()
            };
            if(member != null)
            {
                homeViewModel.Count = shopingrepository.ShoppingCarts(memberid).Count();
            }
            return homeViewModel;
        }
        public HomeViewModel About(string memberid)
        {
            var memberRepository = ContainerManager.Container.GetInstance<MemberRepository>();
            var shopingrepository = ContainerManager.Container.GetInstance<ShoppingCartRepository>();
            var member = memberRepository.FindById(memberid);
            User user = new User();
            if (member != null)
            {
                user.UserID = memberid;
                user.Username = member.Name;
            }
            var homeViewModel = new HomeViewModel()
            {
                User = user
            };
            if(member != null)
            {
                homeViewModel.Count = shopingrepository.ShoppingCarts(memberid).Count();
            }
            return homeViewModel;
        }
        public HomeViewModel Contact(string memberid)
        {
            var memberRepository = ContainerManager.Container.GetInstance<MemberRepository>();
            var shopingrepository = ContainerManager.Container.GetInstance<ShoppingCartRepository>();
            var member = memberRepository.FindById(memberid);
            User user = new User();
            if (member != null)
            {
                user.UserID = memberid;
                user.Username = member.Name;
            }
            var homeViewModel = new HomeViewModel()
            {
                User = user
            };
            if(member != null)
            {
                homeViewModel.Count = shopingrepository.ShoppingCarts(memberid).Count();
            }
            return homeViewModel;
        }
    }
}