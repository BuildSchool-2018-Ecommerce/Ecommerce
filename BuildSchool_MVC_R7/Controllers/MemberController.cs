﻿using BuildSchool.MvcSolution.OnlineStore.Models;
using BuildSchool.MvcSolution.OnlineStore.Repository;
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
            if (Request.Cookies["R7CompanyMember"] == null)
            {
                var memberservice = new MemberService();
                var member = memberservice.SignUp(Data);
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult LogOut()
        {
            var cookie = Request.Cookies["R7CompanyMember"];
            if(cookie != null)
            {
                cookie.Expires = DateTime.Now;
                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Account_Member()
        {
            if (Request.Cookies["R7CompanyMember"] == null)
            {
                return RedirectToAction("LogIn", "Member");
            }
            else
            {
                var memberservice = new MemberService();
                var cookie = Request.Cookies["R7CompanyMember"];
                var member = memberservice.GetMemberById(cookie.Value);
                return View(member);
            }
        }
        public ActionResult Account_Order()
        {
            if (Request.Cookies["R7CompanyMember"] == null)
            {
                return RedirectToAction("LogIn", "Member");
            }
            else
            {
                return View();
            }
            
        }
        public ActionResult Account_UpdateMember()
        {
            if (Request.Cookies["R7CompanyMember"] == null)
            {
                return RedirectToAction("LogIn", "Member");
            }
            else
            {
                var memberservice = new MemberService();
                var cookie = Request.Cookies["R7CompanyMember"];
                var member = memberservice.GetMemberById(cookie.Value);
                return View(member);
            }
        }
        [HttpPost]
        public ActionResult Account_UpdateMember(Members member)
        {
            var memberRepository = new MemberRepository();
            memberRepository.Update(member);
            return RedirectToAction("Account_Member", "Member");
        }
        public ActionResult Account_SearchStatus(string status)
        {
            if (Request.Cookies["R7CompanyMember"] == null)
            {
                return RedirectToAction("LogIn", "Member");
            }
            else
            {
                var memberservice = new MemberService();
                var cookie = Request.Cookies["R7CompanyMember"];
                var member = memberservice.GetOrderById(cookie.Value);
                ViewBag.status = status;
                return View(member);
            }
        }
        public ActionResult Account_SearchTime()
        {
            if (Request.Cookies["R7CompanyMember"] == null)
            {
                return RedirectToAction("LogIn", "Member");
            }
            else
            {
                var memberservice = new MemberService();
                var cookie = Request.Cookies["R7CompanyMember"];
                var member = memberservice.GetOrderByDate(cookie.Value);
                return View(member);
            }
        }
        public ActionResult Account_SearchOrder(string ID)
        {
            if (Request.Cookies["R7CompanyMember"] == null)
            {
                return RedirectToAction("LogIn", "Member");
            }
            else
            {
                var memberservice = new MemberService();
                var cookie = Request.Cookies["R7CompanyMember"];
                var member = memberservice.GetOrderById(cookie.Value);
                ViewBag.ID = ID;
                return View(member);
            }
        }
    }
}