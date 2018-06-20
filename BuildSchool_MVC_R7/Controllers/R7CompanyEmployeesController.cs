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
                return View("LogIn", vm);
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
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            var productRepository = ContainerManager.Container.GetInstance<ProductRepository>();
            productRepository.Create(product);
            return RedirectToAction("ProductList");
        }
        public ActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEmployee(Employees employee)
        {
            var employeeRepository = ContainerManager.Container.GetInstance<EmployeesRepository>();
            employeeRepository.Create(employee);
            return RedirectToAction("EmployeeList");
        }
        public ActionResult EmployeeList()
        {
            var employeeService = new EmployeeService();
            var employeeList = employeeService.GetEmployees();
            return View(employeeList);
        }
        public ActionResult EmployeeModify(int EmployeeID)
        {
            ViewBag.EmployeeID = EmployeeID;
            var employeeService = new EmployeeService();
            var employeeModify = employeeService.GetEmployeesByEmployeeID(EmployeeID);
            return PartialView(employeeModify);
        }
        public ActionResult UpdateEmployee(Employees employee)
        {
            var employeeRepository = ContainerManager.Container.GetInstance<EmployeesRepository>();
            employeeRepository.Update(employee);
            return RedirectToAction("EmployeeList");
        }
        public ActionResult DeleteEmployee(Employees employee)
        {
            var employeeRepository = ContainerManager.Container.GetInstance<EmployeesRepository>();
            employeeRepository.Delete(employee);
            return RedirectToAction("EmployeeList");
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
            var productFormatRepository = ContainerManager.Container.GetInstance<ProductFormatRepository>();
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
            var productRepository = ContainerManager.Container.GetInstance<ProductRepository>();
            productRepository.UpdateProductInfo(productInfo);
            return RedirectToAction("ProductList");
        }

        public ActionResult DeleteProduct(int ProductID)
        {
            var productRepository = ContainerManager.Container.GetInstance<ProductRepository>();
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
            var memberRepository = ContainerManager.Container.GetInstance<MemberRepository>();
            memberRepository.Update(member);
            return RedirectToAction("MemberList");
        }
        public ActionResult ProductSales()
        {
            var productService = new ProductService();
            var product = productService.salesProducts();
            return View(product);
        }
    }
}