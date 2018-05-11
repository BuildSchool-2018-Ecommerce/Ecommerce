using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildSchool.MvcSolution.OnlineStore.Repository;
using System.Linq;

namespace CommerceTest
{
    [TestClass]
    public class TestGetFunction
    {
        #region 其他測試屬性
        //
        // 您可以使用下列其他屬性撰寫測試: 
        //
        // 執行該類別中第一項測試前，使用 ClassInitialize 執行程式碼
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在類別中的所有測試執行後，使用 ClassCleanup 執行程式碼
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在執行每一項測試之前，先使用 TestInitialize 執行程式碼 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在執行每一項測試之後，使用 TestCleanup 執行程式碼
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        //[TestMethod]
        //public void Test_GetCategoryName()
        //{
        //    var repository = new CategoryRepository();
        //    var category = repository.FindCategoryName("abc");
        //    Assert.IsNull(category);
        //}
        [TestMethod]
        public void Test_FindByProductName()
        {
            var repository = new ProductRepository();
            var product = repository.FindByProductName("abc");
            Assert.IsNull(product);
        }
        [TestMethod]
        public void Test_FindByName()
        {
            var repository = new EmployeesRepository();
            var employee = repository.FindByName("abc");
            Assert.IsNull(employee);
        }
        [TestMethod]
        public void Test_GetStatus()
        {
            var repository = new OrdersRepository();
            var orders = repository.GetStatus("出貨中");
            Assert.IsTrue(orders.Count() == 0);
        }
        [TestMethod]
        public void Test_GetOrderDate()
        {
            var repository = new OrdersRepository();
            var orders = repository.GetOrderDate("1999/05/01");
            Assert.IsTrue(orders.Count() == 0);
        }
        [TestMethod]
        public void Test_FindByHireYear()
        {
            var repository = new EmployeesRepository();
            var employee = repository.FindByHireYear(1900, 2000);
            Assert.IsTrue(employee.Count() == 0);
        }
    }
}
