 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int StyleId { get; set; }
        public Style Style { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public int DiscountRate { get; set; } = 0;
        public int SalesQuantity { get; set; } = 0;
        public int StockQuantity { get; set; } = 0;
    }

} 
