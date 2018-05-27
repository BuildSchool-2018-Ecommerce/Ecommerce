using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MvcSolution.OnlineStore.Models
{
    public class Activity
    {
        public int ActivityID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Discount { get; set; }
        public string Image { get; set; }
        public string Introduce { get; set; }
    }
}
