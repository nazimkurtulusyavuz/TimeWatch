using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class SingleProductFilterSpecification : Specification<Product>
    {
        public SingleProductFilterSpecification(string input)
        {
            Query.Include(x => x.Category).Include(x => x.Brand).Include(x => x.Style).Where(x => x.Name == input);
        }
    }
}
