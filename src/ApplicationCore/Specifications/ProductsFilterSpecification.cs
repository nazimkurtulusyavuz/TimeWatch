using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class ProductsFilterSpecification : Specification<Product>
    {
        public ProductsFilterSpecification(string input)
        {
            if (input == "createdTime") 
            {
                Query.OrderByDescending(x => x.CreatedTime);
            }
            if (input == "stockQuantity")
            {
                Query.OrderBy(x => x.StockQuantity);
            }
            if (input == "salesQuantity")
            {
                Query.OrderByDescending(x => x.SalesQuantity);
            }
            if (input == "discountRate")
            {
                Query.Where(x => x.DiscountRate != 0).OrderByDescending(x => x.DiscountRate);
            }
            Query.Take(12);  
        }
        
        public ProductsFilterSpecification(string category, string brand, string style)
        {
            Query.Include(x => x.Category).Include(x => x.Brand).Include(x => x.Style);
            if (category != null)
                Query.Where(x => x.Category.Name == category);
            if (brand != null)
                Query.Where(x => x.Brand.Name == brand);
            if (style != null)
                Query.Where(x => x.Style.Name == style);
        }
       
        public ProductsFilterSpecification(string category, string brand, string style, int page, int itemsPerPage) : this(category, brand, style)
        {
            Query.Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
        }
    }
}
