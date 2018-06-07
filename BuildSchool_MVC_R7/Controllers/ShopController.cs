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
        public ActionResult Index()
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
        public ActionResult Product(int productid)
        {
            var shopService = new ShopService();
            var shop = shopService.FindProductByProductID(productid, "0");
            if (Request.Cookies["R7CompanyMember"] != null)
            {
                shop = shopService.FindProductByProductID(productid, Request.Cookies["R7CompanyMember"].Value);
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