using BuildSchool.MvcSolution.OnlineStore.Models;
using BuildSchool_MVC_R7.Models;
using BuildSchool_MVC_R7.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.WebPages;

namespace BuildSchool_MVC_R7.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
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
        [HttpPost]
        public ActionResult Update(string shop)
        {
            if (Request.Cookies["R7CompanyMember"] == null)
            {
                Response.SetStatus(HttpStatusCode.BadRequest);
                return RedirectToAction("LogIn", "Member");
            }
            JavaScriptSerializer JSONSerializer = new JavaScriptSerializer();
            var json = JSONSerializer.Deserialize<UpdateShoppingCart>(shop);
            var shopservice = new ShopingCartService();
            var shops = shopservice.UpdateProduct(Request.Cookies["R7CompanyMember"].Value, json);
            if(shops == false)
            {
                Response.SetStatus(HttpStatusCode.BadRequest);
                return RedirectToAction("LogIn", "Member");
            }
            return null;
        }
        public ActionResult CheckOut()
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
            return View(shop);
        }
    }
}