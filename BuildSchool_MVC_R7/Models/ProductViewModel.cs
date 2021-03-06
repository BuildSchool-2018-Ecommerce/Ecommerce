﻿using BuildSchool.MvcSolution.OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildSchool_MVC_R7.Models
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { set; get; }

        public Product Product { set; get; }
    }
}