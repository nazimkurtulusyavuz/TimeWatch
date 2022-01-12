using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal PriceBeforeDiscount
        {
            get
            {
                return Price + (Price * DiscountRate / 100);
            }
        }

        public string PictureUri { get; set; }
        public int DiscountRate { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string StyleName { get; set; }
        public int StockQuantity { get; set; } 
        public string PriceText => "$" + Price.ToString("n2");
        public string PriceBeforeDiscountText => "$" + PriceBeforeDiscount.ToString("n2");
    }
}
