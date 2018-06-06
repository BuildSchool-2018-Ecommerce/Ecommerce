using BuildSchool.MvcSolution.OnlineStore.Models;
using BuildSchool_MVC_R7.Models;
using BuildSchool_MVC_R7.Service;
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
            //LoginVM vm = new LoginVM() { ReturnUrl = ReturnUrl };
            if (Request.Cookies["R7CompanyMember"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (ReturnUrl == "null")
            {
                ViewBag.Error = "帳號或密碼輸入錯誤";
            }
            LogInV v = new LogInV();
            return View(v);
        }
        //[AllowAnonymous]
        [HttpPost]
        public ActionResult VerifyLogIn(/*LoginVM vm*/LogInV LV)
        {
            var loginservice = new LogInService();
            var login = loginservice.LogIn(LV.Account, LV.Password);
            if(login == null)
            {
                return RedirectToAction("LogIn", "Member", new { ReturnUrl = "null" });
            }
            Response.Cookies.Add(login);
            //if (!ModelState.IsValid)
            //{
            //    return View("LogIn",vm);
            //}

            //FormsAuthentication.RedirectFromLoginPage(vm.Account, false);
            //return Redirect(FormsAuthentication.GetRedirectUrl(vm.Account, false));
            return RedirectToAction("Index", "Home");
        }
        //[AllowAnonymous]
        public ActionResult SignUp()
        {
            if(Request.Cookies["R7CompanyMember"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            Member_SignUpViewModel Data = new Member_SignUpViewModel();
            return View(Data);
        }
        //[AllowAnonymous]
        [HttpPost]
        public ActionResult SignUp([Bind(Include = "MemberID, password, name, Phone, Address, Email")] Members Data)
        {
            return RedirectToAction("Index", "Home");
        }
        public ActionResult LogOut()
        {
            var cookie = Request.Cookies["R7CompanyMember"];
            cookie.Expires = DateTime.Now;
            Response.Cookies.Add(cookie);
            //Response.Write("<script>location ='xxx.aspx'</script>");
            //Response.Write("<script language=javascript>self.location=document.referrer;</script>");
            return RedirectToAction("Index", "Home");
        }
    }
}