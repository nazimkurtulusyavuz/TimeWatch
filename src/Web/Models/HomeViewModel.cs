using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class HomeViewModel
    {
        public List<ProductViewModel> MostRecentProducts { get; set; } 
        public List<ProductViewModel> MostPopularProducts { get; set; }  
        public List<ProductViewModel> AboutToRunOutProducts { get; set; } 
        public List<ProductViewModel> DiscountProducts { get; set; } 
        public PaginationInfoViewModel PaginationInfoForMostPopularProducts { get; set; }
    }
}
