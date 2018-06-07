using BuildSchool_MVC_R7.Models;
using BuildSchool_MVC_R7.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildSchool_MVC_R7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var homeservice = new HomeService();
            var home = homeservice.Home("0");
            if (Request.Cookies["R7CompanyMember"] != null)
            {
                home = homeservice.Home(Request.Cookies["R7CompanyMember"].Value);
            } 
            return View(home);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}