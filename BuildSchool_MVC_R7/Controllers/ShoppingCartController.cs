using BuildSchool_MVC_R7.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace BuildSchool_MVC_R7.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
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
    }
}