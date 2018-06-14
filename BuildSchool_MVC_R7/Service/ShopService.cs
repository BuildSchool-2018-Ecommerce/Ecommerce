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
        public ShopViewModel Shop(string memberid, string low, string high, string Orderby)
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
            if(low!=null && high != null)
            {
                var p = new List<AllProduct>();
                foreach (var item in shopViewModel.AllProduct)
                {
                    if(item.Sale == 0)
                    {
                        if(item.UnitPrice >= decimal.Parse(low) && item.UnitPrice <=decimal.Parse(high))
                        {
                            p.Add(item);
                        }
                    }
                    else
                    {
                        if (item.Sale >= decimal.Parse(low) && item.Sale <= decimal.Parse(high))
                        {
                            p.Add(item);
                        }
                    }
                }
                shopViewModel.AllProduct = p;
            }
            if(Orderby == "1")
            {
                var p = new List<AllProduct>();
                foreach (var item in shopViewModel.AllProduct)
                {
                    if (item.Sale == 0)
                    {
                        if (item.UnitPrice >= decimal.Parse(low))
                        {
                            p.Add(item);
                        }
                    }
                    else
                    {
                        if (item.Sale >= decimal.Parse(low))
                        {
                            p.Add(item);
                        }
                    }
                }
                shopViewModel.AllProduct = p;
            }
            if (member != null)
            {
                shopViewModel.Count = shopingrepository.ShoppingCarts(memberid).Count();
            }
            return shopViewModel;
        }
        public ShopViewModel CategoryShop(int categoryid, string memberid, string low, string high, string Orderby)
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
            if (low != null && high != null)
            {
                var p = new List<CategoryProduct>();
                foreach (var item in shopViewModel.CategoryProduct)
                {
                    if (item.Sale == 0)
                    {
                        if (item.UnitPrice >= decimal.Parse(low) && item.UnitPrice <= decimal.Parse(high))
                        {
                            p.Add(item);
                        }
                    }
                    else
                    {
                        if (item.Sale >= decimal.Parse(low) && item.Sale <= decimal.Parse(high))
                        {
                            p.Add(item);
                        }
                    }
                }
                shopViewModel.CategoryProduct = p;
            }
            if (Orderby == "1")
            {
                var p = new List<AllProduct>();
                foreach (var item in shopViewModel.AllProduct)
                {
                    if (item.Sale == 0)
                    {
                        if (item.UnitPrice >= decimal.Parse(low))
                        {
                            p.Add(item);
                        }
                    }
                    else
                    {
                        if (item.Sale >= decimal.Parse(low))
                        {
                            p.Add(item);
                        }
                    }
                }
                shopViewModel.AllProduct = p;
            }
            if (member != null)
            {
                shopViewModel.Count = shopingrepository.ShoppingCarts(memberid).Count();
            }
            return shopViewModel;
        }
        public string CreateShoppingCart(string memberid, int productid, string color, string size, int quantity)
        {
            var productRepository = ContainerManager.Container.GetInstance<ProductRepository>();
            var product = productRepository.FindProductFormatByProductID(productid).ToList();
            var shopingrepository = ContainerManager.Container.GetInstance<ShoppingCartRepository>();
            var memberRepository = ContainerManager.Container.GetInstance<MemberRepository>();
            var member = memberRepository.FindById(memberid);
            if (member != null)
            {
                var pd = product.FirstOrDefault((x) => x.Color == color && x.Size == size);
                if(pd != null)
                {
                    if (pd.StockQuantity - quantity < 0)
                    {
                        return "庫存不足";
                    }
                    var shop = new ShoppingCart()
                    {
                        MemberID = member.MemberID,
                        Quantity = quantity,
                        ProductFormatID = pd.ProductFormatID
                    };
                    var shoppingcart = shopingrepository.ShoppingCarts(memberid);
                    var p = shoppingcart.FirstOrDefault((x) => x.ProductFormatID == shop.ProductFormatID);
                    if(p == null)
                    {
                        shopingrepository.Create(shop);
                    }
                    else
                    {
                        shop.ShoppingCartID = p.ShoppingCartID;
                        shop.Quantity = quantity + p.Quantity;
                        if (pd.StockQuantity - shop.Quantity < 0)
                        {
                            return "庫存不足";
                        }
                        shopingrepository.Update(shop);
                    }
                    return "OK";
                }
                return "查無此產品";
            }
            return "查無此會員";
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
        public ShopViewModel SearchProduct(string memberid , string productname, string low, string high, string Orderby)
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
                SearchProduct = productRepository.SearchProduct("%"+productname+"%").ToList(),
                MaxUnitPrice = productRepository.MaxUnitPrice()
            };
            if (low != null && high != null)
            {
                var p = new List<SearchProduct>();
                foreach (var item in shopViewModel.SearchProduct)
                {
                    if (item.Sale == 0)
                    {
                        if (item.UnitPrice >= decimal.Parse(low) && item.UnitPrice <= decimal.Parse(high))
                        {
                            p.Add(item);
                        }
                    }
                    else
                    {
                        if (item.Sale >= decimal.Parse(low) && item.Sale <= decimal.Parse(high))
                        {
                            p.Add(item);
                        }
                    }
                }
                shopViewModel.SearchProduct = p;
            }
            if (Orderby == "1")
            {
                var p = new List<SearchProduct>();
                foreach (var item in shopViewModel.SearchProduct)
                {
                    if (item.Sale == 0)
                    {
                        if (item.UnitPrice >= decimal.Parse(low))
                        {
                            p.Add(item);
                        }
                    }
                    else
                    {
                        if (item.Sale >= decimal.Parse(low))
                        {
                            p.Add(item);
                        }
                    }
                }
                shopViewModel.SearchProduct = p;
            }
            if (member != null)
            {
                shopViewModel.Count = shopingrepository.ShoppingCarts(memberid).Count();
            }
            return shopViewModel;
        }
    }
}