using BuildSchool.MvcSolution.OnlineStore.Models;
using BuildSchool_MVC_R7.App_Start;
using BuildSchool.MvcSolution.OnlineStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildSchool_MVC_R7.Service
{
    public class ShopingCartService
    {
        public IEnumerable<ShoppingIconView> ShoppingCarts(string memberid)
        {
            var shopingrepository = ContainerManager.Container.GetInstance<ShoppingCartRepository>();
            var memberrepository = ContainerManager.Container.GetInstance<MemberRepository>();
            var member = memberrepository.FindById(memberid);
            if(member != null)
            {
                var shop = shopingrepository.ShoppingCarts(memberid);
                return shop;
            }
            return null;
        }
    }
}