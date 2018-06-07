using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildSchool.MvcSolution.OnlineStore.Models;


namespace BuildSchool_MVC_R7.Models
{
    public class MemberViewModel
    {
        public IEnumerable<Members> Members { set; get; }

        public Members Member { set; get; }
    }
}