using BuildSchool.MvcSolution.OnlineStore.Models;
using BuildSchool_MVC_R7.App_Start;
using BuildSchool_MVC_R7.Models;
using BuildSchool.MvcSolution.OnlineStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildSchool_MVC_R7.Service
{
    public class ShopingCartService
    {
        public ShoppingCartViewModel ShoppingCarts(string memberid)
        {
            var shopingrepository = ContainerManager.Container.GetInstance<ShoppingCartRepository>();
            var memberrepository = ContainerManager.Container.GetInstance<MemberRepository>();
            var member = memberrepository.FindById(memberid);
            var user = new User();
            if(member != null)
            {
                user.UserID = member.MemberID;
                user.Username = member.Name;
                var shoppingcartviewmodel = new ShoppingCartViewModel()
                {
                    User = user,
                    ShoppingIconView = shopingrepository.ShoppingCarts(memberid)
                };
                return shoppingcartviewmodel;
            }
            return null;
        }
        public bool DelectProduct(string memberid,int productformatid)
        {
            var shopingrepository = ContainerManager.Container.GetInstance<ShoppingCartRepository>();
            var memberrepository = ContainerManager.Container.GetInstance<MemberRepository>();
            var member = memberrepository.FindById(memberid);
            if (member != null)
            {
                var shop = shopingrepository.FindShoppingCartsByMemberId(memberid);
                var product = shop.FirstOrDefault((x) => x.ProductFormatID == productformatid);
                if(product == null)
                {
                    return false;
                }
                shopingrepository.Delete(product);
                return true;
            }
            return false;
        }
    }
}