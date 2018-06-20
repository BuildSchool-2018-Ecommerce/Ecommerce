using BuildSchool.MvcSolution.OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildSchool_MVC_R7.Models
{
    public class EmployeeViewModel
    {
        public IEnumerable<Employees> Employees { set; get; }

        public Employees Employee { set; get; }
    }
}