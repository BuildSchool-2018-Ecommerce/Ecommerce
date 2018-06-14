using BuildSchool.MvcSolution.OnlineStore.Models;
using BuildSchool_MVC_R7.Models;
using BuildSchool_MVC_R7.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.WebPages;

namespace BuildSchool_MVC_R7.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Cart()
        {
            if(Request.Cookies["R7CompanyMember"] == null)
            {
                return RedirectToAction("LogIn", "Member");
            }
            var shopservice = new ShopingCartService();
            var shop = shopservice.ShoppingCarts(Request.Cookies["R7CompanyMember"].Value);
            if (shop == null)
            {
                return RedirectToAction("LogIn", "Member");
            }
            return View(shop);
        }
        public ActionResult ShoppingBar()
        {
            if(Request.Cookies["R7CompanyMember"] != null)
            {
                var shopservice = new ShopingCartService();
                var shop = shopservice.ShoppingCarts(Request.Cookies["R7CompanyMember"].Value);
                if(shop == null)
                {
                    Response.SetStatus(HttpStatusCode.BadRequest);
                    return RedirectToAction("LogIn", "Member");
                }
                return PartialView(shop);
            }
            Response.SetStatus(HttpStatusCode.BadRequest);
            return RedirectToAction("LogIn", "Member");
        }
        public ActionResult DeleteProduct(string pfid)
        {
            if (Request.Cookies["R7CompanyMember"] == null)
            {
                Response.SetStatus(HttpStatusCode.BadRequest);
                return RedirectToAction("LogIn", "Member");
            }
            var shopservice = new ShopingCartService();
            var shop = shopservice.DelectProduct(Request.Cookies["R7CompanyMember"].Value, int.Parse(pfid));
            if (shop == false)
            {
                Response.SetStatus(HttpStatusCode.BadRequest);
                return RedirectToAction("LogIn", "Member");
            }
            return View();
        }
        public ActionResult Update(string shop)
        {
            if (Request.Cookies["R7CompanyMember"] == null)
            {
                Response.SetStatus(HttpStatusCode.BadRequest);
                return null;
            }
            JavaScriptSerializer JSONSerializer = new JavaScriptSerializer();
            var json = JSONSerializer.Deserialize<UpdateShoppingCart>(shop);
            var shopservice = new ShopingCartService();
            string shops = shopservice.UpdateProduct(Request.Cookies["R7CompanyMember"].Value, json);
            if(shops == "OK")
            {
                return null;
            }
            Response.StatusCode = 400;
            //設定TrySkipIisCustomErrors，停用IIS自訂錯誤頁面
            Response.TrySkipIisCustomErrors = true;
            return Content(shops, "application/json");
        }
        public ActionResult CheckOut(string Error)
        {
            if (Request.Cookies["R7CompanyMember"] == null)
            {
                return RedirectToAction("LogIn", "Member");
            }
            var shopservice = new ShopingCartService();
            var shop = shopservice.ShoppingCarts(Request.Cookies["R7CompanyMember"].Value);
            if (shop == null)
            {
                return RedirectToAction("LogIn", "Member");
            }
            if (shop.Count == 0)
            {
                return RedirectToAction("ShopHomePage", "Shop");
            }
            ViewBag.Error = Error;
            return View(shop);
        }
        [HttpPost]
        public ActionResult CreateOrder(Orders orders)
        {
            if (Request.Cookies["R7CompanyMember"] == null)
            {
                return RedirectToAction("LogIn", "Member");
            }
            string shop = "請完整輸入";
            if(orders.ShipName != null && orders.ShipAddress != null && orders.ShipPhone != null)
            {
                var shopservice = new ShopingCartService();
                shop = shopservice.CreateOrders(Request.Cookies["R7CompanyMember"].Value, orders);
                if (shop == "Ok")
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("CheckOut", "ShoppingCart", new { Error = shop });
        }
        public ActionResult ShoppingSuccess()
        {
            if (Request.Cookies["R7CompanyMember"] == null)
            {
                return RedirectToAction("LogIn", "Member");
            }
            var shopservice = new ShopingCartService();
            var shop = shopservice.ShoppingSucces(Request.Cookies["R7CompanyMember"].Value);
            if (shop == null)
            {
                return RedirectToAction("LogIn", "Member");
            }
            return View(shop);
        }
    }
}