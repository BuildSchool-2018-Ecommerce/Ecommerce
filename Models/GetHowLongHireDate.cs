﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MvcSolution.OnlineStore.Models
{
    public class GetHowLongHireDate
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime HireDate { get; set; }
        public int HowLong {get;set;}
    }
}
