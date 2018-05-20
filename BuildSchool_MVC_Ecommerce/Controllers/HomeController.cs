using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildSchool.MvcSolution.OnlineStore.Models;
using BuildSchool.MvcSolution.OnlineStore.Repository;

namespace BuildSchool_MVC_Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var categoryrepository = new CategoryRepository();
            var allcategory = categoryrepository.GetAll();
            ViewData["allcategory"] = allcategory;
            var productrepository = new ProductRepository();
            var newproduct = productrepository.GetAll();
            ViewData["newproduct"] = newproduct.Take(10);
            var hotproduct = productrepository.GetHotProduct();
            ViewData["hotproduct"] = hotproduct.Take(10);

            return View();
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
        public ActionResult NotLogInBar()
        {
            return PartialView();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}