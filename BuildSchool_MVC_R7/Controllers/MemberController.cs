using BuildSchool.MvcSolution.OnlineStore.Models;
using BuildSchool_MVC_R7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BuildSchool_MVC_R7.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult VerifyLogIn(string account, string password)
        {
            if(account=="123" && password=="123")
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    
                    );
            }
            return RedirectToAction("LogIn");
        }
        [Authorize]
        public ActionResult test()
        {
            return Content("登入成功");
        }
        public ActionResult SignUp()
        {
            Member_SignUpViewModel Data = new Member_SignUpViewModel();
            return View(Data);
        }
        [HttpPost]
        public ActionResult SignUp([Bind(Include = "MemberID, password, name, Phone, Address, Email")] Members Data)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}