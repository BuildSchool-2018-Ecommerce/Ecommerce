using BuildSchool.MvcSolution.OnlineStore.Models;
using BuildSchool.MvcSolution.OnlineStore.Repository;
using BuildSchool_MVC_R7.App_Start;
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
    [Authorize]
    public class R7CompanyEmployeesController : Controller
    {
        // GET: R7CompanyEmployees
        [AllowAnonymous]
        public ActionResult Index(string ReturnUrl)
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
                return View("Index", vm);
            }

            FormsAuthentication.RedirectFromLoginPage(vm.Account, false);
            return Redirect(FormsAuthentication.GetRedirectUrl(vm.Account, false));
        }

        public ActionResult ProductList()
       {
            var productService = new ProductService();
            var productList = productService.GetProducts();
            return View(productList);
        }
    
        public ActionResult ProductListByCategoryName(string CategoryName)
        {
            var productService = new ProductService();
            var productList = productService.GetProductsByCategoryName(CategoryName);
            return View(productList);
        }

        public ActionResult ProductByProductName(string ProductName)
        {
            var productServie = new ProductService();
            var product = productServie.GetProductByProductName(ProductName);
            return PartialView(product);
        }

        public ActionResult ProductFormatDetail(int ProductID)
        {
            var productService = new ProductService();
            var productFormatList = productService.GetProductFormatByProductID(ProductID);
            return PartialView(productFormatList);
        }
        
        public ActionResult ProductFormatModify(int ProductFormatID)
        {
            ViewBag.ProductFormatID = ProductFormatID;
            var productService = new ProductService();
            var productFormatViewModel = productService.GetProductDetailByProductFormatID(ProductFormatID);
            return PartialView(productFormatViewModel);
        }

        public ActionResult UpdataProductFormat(ProductFormat productFormatInfo)
        {
            var productFormatRepository = new ProductFormatRepository();
            productFormatRepository.UpdateProductFormat(productFormatInfo);
            return RedirectToAction("ProductList");
        }

        public ActionResult ProductModify(int ProductID)
        {
            ViewBag.ProductID = ProductID;
            var productService = new ProductService();
            var productDetailViewModel = productService.GetProductDetailByProductID(ProductID);
            return PartialView(productDetailViewModel);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product productInfo)
        {
            var productRepository = new ProductRepository();
            productRepository.UpdateProductInfo(productInfo);
            return RedirectToAction("ProductList");
        }

        public ActionResult DeleteProduct(int ProductID)
        {
            var productRepository = new ProductRepository();
            productRepository.Delete(ProductID);
            return RedirectToAction("ProductList");
        }

        public ActionResult OrderList()
        {
            var orderService = new OrderService();
            var orderList = orderService.GetOrders();
            return View(orderList);
        }

        public ActionResult OrderDetail(int orderID)
        {
            ViewBag.OrderID = orderID;
            var orderService = new OrderService();
            var orderDetailList = orderService.GetOrderDetailByOrderID(orderID);
            return PartialView(orderDetailList);
        }

        //public ActionResult OrderDetailModify(int OrderID)
        //{
        //    ViewBag.OrderID = OrderID;
        //}

        public ActionResult MemberList()
        {
            var memberService = new MemberService();
            var memberList = memberService.GetMembers();
            return View(memberList);
        }
        
        public ActionResult MemberDetail(string memberId)
        {
            ViewBag.MemberID = memberId;
            var memberService = new MemberService();
            var memberDetail = memberService.GetMemberById(memberId);
            return PartialView(memberDetail);
        }

        public ActionResult UpdateMemberInfo(Members member)
        {
            var memberRepository = new MemberRepository();
            memberRepository.Update(member);
            return RedirectToAction("MemberList");
        }
    }
}