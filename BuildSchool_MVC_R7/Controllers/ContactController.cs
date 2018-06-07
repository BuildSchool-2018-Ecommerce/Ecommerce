using BuildSchool_MVC_R7.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildSchool_MVC_R7.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var homeservice = new HomeService();
            var home = homeservice.Contact("0");
            if (Request.Cookies["R7CompanyMember"] != null)
            {
                home = homeservice.Contact(Request.Cookies["R7CompanyMember"].Value);
            }
            return View(home);
        }
    }
}