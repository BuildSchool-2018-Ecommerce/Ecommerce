using BuildSchool.MvcSolution.OnlineStore.Models;
using BuildSchool_MVC_R7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildSchool_MVC_R7.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult LogIn()
        {
            return View();
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