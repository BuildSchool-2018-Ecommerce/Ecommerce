using BuildSchool.MvcSolution.OnlineStore.Models;
using BuildSchool.MvcSolution.OnlineStore.Repository;
using BuildSchool_MVC_R7.App_Start;
using BuildSchool_MVC_R7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildSchool_MVC_R7.Service
{
    public class EmployeeService
    {
        public EmployeeViewModel GetEmployees()
        {
            var employeeRepository = ContainerManager.Container.GetInstance<EmployeesRepository>();
            var employeeViewModel = new EmployeeViewModel()
            {
                Employees = employeeRepository.GetAll().ToList()
            };
            return employeeViewModel;
        }
        public EmployeeViewModel GetEmployeesByEmployeeID(int EmployeeID)
        {
            var employeeRepository = ContainerManager.Container.GetInstance<EmployeesRepository>();
            var employeeViewModel = new EmployeeViewModel()
            {
                Employee = employeeRepository.FindById(EmployeeID)
            };
            return employeeViewModel;
        }
    }
}