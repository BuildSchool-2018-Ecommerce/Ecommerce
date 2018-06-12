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
        public ActionResult ShopHomePage()
        {
            
            var shopService = new ShopService();
            var shop = shopService.Shop("0");
            if (Request.Cookies["R7CompanyMember"] != null)
            {
                shop = shopService.Shop(Request.Cookies["R7CompanyMember"].Value);
            }
            return View(shop);
        }
        public ActionResult CategoryProduct(int categoryid)
        {
            var shopService = new ShopService();
            var shop = shopService.CategoryShop(categoryid, "0");
            if (Request.Cookies["R7CompanyMember"] != null)
            {
                shop = shopService.CategoryShop(categoryid, Request.Cookies["R7CompanyMember"].Value);
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