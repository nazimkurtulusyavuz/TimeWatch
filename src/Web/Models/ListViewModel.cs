using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;

namespace Web.Models
{
    public class ListViewModel 
    {
        public List<ProductViewModel> Products { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Brands { get; set; }
        public List<SelectListItem> Styles { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Style { get; set; }
        public PaginationInfoViewModel PaginationInfo { get; set; }
    }
}
