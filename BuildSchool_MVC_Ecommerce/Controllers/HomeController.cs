using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildSchool.MvcSolution.OnlineStore.Models;
using BuildSchool.MvcSolution.OnlineStore.Repository;
using System.Web.Script.Serialization;

namespace BuildSchool_MVC_Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            JavaScriptSerializer JSONSerializer = new JavaScriptSerializer();
            var categoryrepository = new CategoryRepository();
            var allcategory = categoryrepository.GetAll();
            ViewData["allcategory"] = allcategory;
            
            if (Request.Cookies["user"] == null)
            {
                ViewData["user"] = null;
            }
            else
            {
                string json = Request.Cookies["user"].Value;
                var user = JSONSerializer.Deserialize<User>(json);
                ViewData["user"] = user.Username;
            }
            //ViewData["user"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult Login(string memberid, string password)
        {
            JavaScriptSerializer JSONSerializer = new JavaScriptSerializer();
            var cookieName = "user";
            var memberrepository = new MemberRepository();
            var member = memberrepository.FindById(memberid);
            if(memberid == member.MemberID && password == member.Password)
            {
                if(Response.Cookies.AllKeys.Contains(cookieName))
                {
                    var cookieVal = Response.Cookies[cookieName].Value;
                    HttpContext.Application.Remove(cookieVal);
                    Response.Cookies.Remove(cookieName);
                }
                var token = Guid.NewGuid().ToString();
                //HttpContext.Application[token] = DateTime.UtcNow.AddHours(12);
                var user = new User()
                {
                    UserID = member.MemberID,
                    Username = member.Name
                };
                string json = JSONSerializer.Serialize(user);
                var hc = new HttpCookie(cookieName, json)
                {
                    Expires = DateTime.Now.AddSeconds(20),
                    HttpOnly = true
                };
                Response.Cookies.Add(hc);
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ShoppingCard()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult HomePage()
        {
            var productrepository = new ProductRepository();
            var newproduct = productrepository.GetAll();
            ViewData["newproduct"] = newproduct.Take(10);
            var hotproduct = productrepository.GetHotProduct();
            ViewData["hotproduct"] = hotproduct.Take(10);
            return PartialView();
        }
        public ActionResult CategoryPage(string categoryName)
        {
            var categoryrepository = new CategoryRepository();
            var productcategory = categoryrepository.FindProductsByCategory();
            var data = productcategory.Where((x) => x.CategoryName == categoryName);
            ViewData["productcategory"] = data;
            return PartialView();
        }
        public ActionResult NotLogInBar()
        {
            //var co = new HttpCookie("User", "123")
            //{
            //    Expires = DateTime.Now.AddSeconds(10),
            //    HttpOnly = true
            //};
            //Response.Cookies.Add(co);
            return PartialView();
        }
        public ActionResult LogInBar(string user)
        {
            ViewData["user"] = user;
            return PartialView();
        }
        public ActionResult LogOut()
        {
            var cookie = Request.Cookies["user"];
            cookie.Expires = DateTime.Now;
            //Request.Cookies.Remove("User");
            //var c = new HttpCookie("User","out")
            //{
            //    Expires = DateTime.UtcNow,
            //    HttpOnly = true
            //};
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}