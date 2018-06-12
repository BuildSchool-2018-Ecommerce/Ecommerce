using BuildSchool.MvcSolution.OnlineStore.Models;
using BuildSchool_MVC_R7.App_Start;
using BuildSchool_MVC_R7.Models;
using BuildSchool.MvcSolution.OnlineStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

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
        public bool DelectProduct(string memberid, int productformatid)
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
        public string UpdateProduct(string memberid, UpdateShoppingCart shopping)
        {
            var shoppingrepository = ContainerManager.Container.GetInstance<ShoppingCartRepository>();
            var memberrepository = ContainerManager.Container.GetInstance<MemberRepository>();
            var productformatrepository = ContainerManager.Container.GetInstance<ProductFormatRepository>();
            var member = memberrepository.FindById(memberid);
            if (member != null)
            {
                var shop = shoppingrepository.FindShoppingCartsByMemberId(memberid);
                for(int i=0;i<shopping.Quantity.Count ; i++)
                {
                    var product = shop.FirstOrDefault((x) => x.ProductFormatID == int.Parse(shopping.ProductFormatID[i]));
                    if(product == null)
                    {
                        return $"查無此產品,{shopping.ProductFormatID[i]}";
                    }
                    var pf = productformatrepository.FindById(int.Parse(shopping.ProductFormatID[i]));
                    if(pf.StockQuantity - int.Parse(shopping.Quantity[i])<0)
                    {
                        return $"產品庫存不足,{pf.ProductFormatID},{pf.StockQuantity}";
                    }
                    product.Quantity = int.Parse(shopping.Quantity[i]);
                    shoppingrepository.Update(product);
                }
                return "OK";
            }
            return "查無使用者";
        }
        public string CreateOrders(string memberid,Orders orders)
        {
            var memberrepository = ContainerManager.Container.GetInstance<MemberRepository>();
            var employeesrepository = ContainerManager.Container.GetInstance<EmployeesRepository>();
            var ordersrepository = ContainerManager.Container.GetInstance<OrdersRepository>();
            var ordertailrepository = ContainerManager.Container.GetInstance<OrderDetailsRepository>();
            var shoppingrepository = ContainerManager.Container.GetInstance<ShoppingCartRepository>();
            var member = memberrepository.FindById(memberid);
            var employees = employeesrepository.GetAll();
            if (member != null)
            {
                orders.OrderDate = DateTime.Now;
                orders.MemberID = member.MemberID;
                orders.Status = "未出貨";
                var sql = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_ProductionDb");

                if (string.IsNullOrEmpty(sql))
                {
                    sql = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
                }
                var connection = new SqlConnection(sql);
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        ordersrepository.Create(orders, connection, transaction);
                        var memberorder = memberrepository.GetBuyerOrder(memberid, connection, transaction);
                        var lastordeer = memberorder.First();
                        var shop = shoppingrepository.ShoppingCarts(memberid, connection, transaction);
                        foreach (var item in shop)
                        {
                            var price = 0M;
                            if(item.Sale == 0)
                            {
                                price = item.UnitPrice;
                            }
                            else
                            {
                                price = item.Sale;
                            }
                            OrderDetails od = new OrderDetails()
                            {
                                OrderID = lastordeer.OrderID,
                                ProductFormatID = item.ProductFormatID,
                                Quantity = item.Quantity,
                                UnitPrice = price
                            };
                            ordertailrepository.Create(od, connection, transaction);
                        }
                        shoppingrepository.DeletebyMemberID(member.MemberID, connection, transaction);
                        transaction.Commit();
                        return "OK";
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return "交易失敗，庫存不足";
                    }

                }
            }
            return "查無此會員";
        }
    }
}