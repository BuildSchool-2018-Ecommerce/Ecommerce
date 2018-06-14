using BuildSchool_MVC_R7.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildSchool_MVC_R7.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult ShopHomePage(string low, string high, string Orderby)
        {
            var shopService = new ShopService();
            var shop = shopService.Shop("0", low, high, Orderby);
            if (Request.Cookies["R7CompanyMember"] != null)
            {
                shop = shopService.Shop(Request.Cookies["R7CompanyMember"].Value, low, high, Orderby);
            }
            if(low!=null && high != null)
            {
                ViewBag.price = "$" + low + " ~ $" + high + " 的商品";
            }
            if(Orderby == "1")
            {
                ViewBag.price = "$" + low + " up的商品";
            }
            return View(shop);
        }
        public ActionResult Search(string productname, string low, string high, string Orderby)
        {
            if(productname == null)
            {
                return RedirectToAction("ShopHomePage", "Shop");
            }
            ViewBag.searchname = productname;
            var shopService = new ShopService();
            var shop = shopService.SearchProduct("0", productname, low, high, Orderby);
            if (Request.Cookies["R7CompanyMember"] != null)
            {
                shop = shopService.SearchProduct(Request.Cookies["R7CompanyMember"].Value, productname, low, high, Orderby);
            }
            if (low != null && high != null)
            {
                ViewBag.price = " , $" + low + " ~ $" + high + " 的商品";
            }
            if (Orderby == "1")
            {
                ViewBag.price = " , $" + low + " up的商品";
            }
            return View(shop);
        }
        public ActionResult CategoryProduct(string categoryid, string low, string high, string Orderby)
        {
            if(categoryid == null)
            {
                return RedirectToAction("ShopHomePage", "Shop");
            }
            var shopService = new ShopService();
            var shop = shopService.CategoryShop(int.Parse(categoryid), "0", low, high, Orderby);
            if (Request.Cookies["R7CompanyMember"] != null)
            {
                shop = shopService.CategoryShop(int.Parse(categoryid), Request.Cookies["R7CompanyMember"].Value, low, high, Orderby);
            }
            if (low != null && high != null)
            {
                ViewBag.price = "$" + low + " ~ $" + high + " 的商品";
            }
            if (Orderby == "1")
            {
                ViewBag.price = "$" + low + " up的商品";
            }
            return View(shop);
        }
        public ActionResult CreateProductInShoppingCart(string productid, string color, string Size, string quantity)
        {
            if (Request.Cookies["R7CompanyMember"] == null)
            {
                Response.StatusCode = 400;
                //設定TrySkipIisCustomErrors，停用IIS自訂錯誤頁面
                Response.TrySkipIisCustomErrors = true;
                return Content("請登入", "application/json");
            }
            var shopService = new ShopService();
            var shop = shopService.CreateShoppingCart(Request.Cookies["R7CompanyMember"].Value, int.Parse(productid), color, Size, int.Parse(quantity));
            if(shop == "OK")
            {
                return null;
            }
            Response.StatusCode = 400;
            //設定TrySkipIisCustomErrors，停用IIS自訂錯誤頁面
            Response.TrySkipIisCustomErrors = true;
            return Content(shop, "application/json");
        }
        public ActionResult Product(string productid)
        {
            if(productid==null)
            {
                return RedirectToAction("Index", "Home");
            }
            var shopService = new ShopService();
            var shop = shopService.FindProductByProductID(int.Parse(productid), "0");
            if (Request.Cookies["R7CompanyMember"] != null)
            {
                shop = shopService.FindProductByProductID(int.Parse(productid), Request.Cookies["R7CompanyMember"].Value);
            }
            return View(shop);
        }
        public ActionResult ProductSize(int productid, string color)
        {
            var shopService = new ShopService();
            var shop = shopService.ProductSize(productid, color);
            return PartialView(shop);
        }
        public ActionResult ProductQuantity(int productid, string color, string size)
        {
            var shopService = new ShopService();
            var shop = shopService.ProductQuantity(productid, color, size);
            return PartialView(shop);
        }
    }
}