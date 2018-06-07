using BuildSchool.MvcSolution.OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildSchool_MVC_R7.Models
{
    public class ProductFormatViewModel
    {
        public IEnumerable<GetProductFormatByProductID> ProductFormat { set; get; }

        public GetProductFormatByProductID ProductFormatInfo { set; get; }
    }
}