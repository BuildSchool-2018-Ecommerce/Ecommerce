
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BuildSchool.MvcSolution.OnlineStore.Models
{
    public class GetProductOrder
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string Description { get; set; }
        public int total { get; set; }
    }
}