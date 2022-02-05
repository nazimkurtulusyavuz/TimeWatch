using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int CategoryCount { get; set; }
        public int StyleCount { get; set; }
        public int BrandCount { get; set; }
        public int ProductCount { get; set; }
        public int UserCount { get; set; }
        public int OrderCount { get; set; }
        //public int CommentCount { get; set; }

    }
}
