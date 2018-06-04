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
    [Authorize]
    public class MemberController : Controller
    {
        // GET: Member
        [AllowAnonymous]
        public ActionResult LogIn(string ReturnUrl)
        {
            LoginVM vm = new LoginVM() { ReturnUrl = ReturnUrl };
            return View(vm);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult VerifyLogIn(LoginVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View("LogIn",vm);
            }
            FormsAuthentication.RedirectFromLoginPage(vm.Account, false);
            return Redirect(FormsAuthentication.GetRedirectUrl(vm.Account, false));
        }
        public ActionResult test()
        {
            return Content("登入成功");
        }
        [AllowAnonymous]
        public ActionResult SignUp()
        {
            Member_SignUpViewModel Data = new Member_SignUpViewModel();
            return View(Data);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult SignUp([Bind(Include = "MemberID, password, name, Phone, Address, Email")] Members Data)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}