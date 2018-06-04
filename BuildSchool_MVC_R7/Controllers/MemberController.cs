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
    //需要驗證
    //[Authorize]
    public class MemberController : Controller
    {
        // GET: Member
        //不用驗證直接過
        //[AllowAnonymous]
        public ActionResult LogIn(string ReturnUrl)
        {
            LoginVM vm = new LoginVM() { ReturnUrl = ReturnUrl };
            return View(vm);
        }
        //[AllowAnonymous]
        [HttpPost]
        public ActionResult VerifyLogIn(/*LoginVM vm*/string account, string password)
        {
            var username = "";
            var userdata = "";
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
                (1, username, DateTime.Now, DateTime.Now.AddMinutes(30), false, userdata, FormsAuthentication.FormsCookiePath);
            // Encrypt the ticket.
            string encTicket = FormsAuthentication.Encrypt(ticket);
            // Create the cookie.
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
            //if (!ModelState.IsValid)
            //{
            //    return View("LogIn",vm);
            //}
            //string userData = "ApplicationSpecific data for this user";

            //string strUsername = "你想要存放在 User.Identy.Name 的值，通常是使用者帳號";

            //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
            //  strUsername,
            //  DateTime.Now,
            //  DateTime.Now.AddMinutes(30),
            //  isPersistent,
            //  userData,
            //  FormsAuthentication.FormsCookiePath);

            //// Encrypt the ticket.
            //string encTicket = FormsAuthentication.Encrypt(ticket);

            //// Create the cookie.
            //Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
            //FormsAuthentication.RedirectFromLoginPage(vm.Account, false);
            //return Redirect(FormsAuthentication.GetRedirectUrl(vm.Account, false));
            return View("Index", "Home");
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
        //[AllowAnonymous]
        [HttpPost]
        public ActionResult SignUp([Bind(Include = "MemberID, password, name, Phone, Address, Email")] Members Data)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}