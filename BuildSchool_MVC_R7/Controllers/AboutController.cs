using BuildSchool_MVC_R7.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildSchool_MVC_R7.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            var homeservice = new HomeService();
            var home = homeservice.About("0");
            if (Request.Cookies["R7CompanyMember"] != null)
            {
                home = homeservice.About(Request.Cookies["R7CompanyMember"].Value);
            }
            return View(home);
        }
    }
}