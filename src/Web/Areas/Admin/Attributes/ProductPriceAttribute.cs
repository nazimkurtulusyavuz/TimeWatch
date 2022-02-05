using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Attributes
{
    public class ProductPriceAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            decimal val;
            if (value == null) return true;
            try
            {
                val = (decimal)value;
            }
            catch (Exception)
            {
                ErrorMessage = "Please enter a number.";
                return false;
            }
            if (val < 0)
            {
                ErrorMessage = "Please enter positive number.";
                return false;
            }
            if (val % 0.25m != 0)
            {
                ErrorMessage = "Please enter multiples of 0,25.";
                return false;
            }
            if (val > 9999999999999999.99m)
            {
                ErrorMessage = "Please enter a number smaller than 10000000000000000";
                return false;
            }
            return true;
        }
    }
}
