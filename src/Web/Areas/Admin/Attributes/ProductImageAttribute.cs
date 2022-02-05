using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Attributes
{
    public class ProductImageAttribute : ValidationAttribute
    {
        public double MaxSizeMB { get; set; } = 0.1d;
        public override bool IsValid(object value)
        {
            if (value == null) return true;
            IFormFile file = (IFormFile)value;
            if (!file.ContentType.StartsWith("image/"))
            {
                ErrorMessage = "The File is not an image.";
                return false;
            }
            if (file.Length > MaxSizeMB * 1000 * 1000)
            {
                ErrorMessage = $"The File cannot be larger than {MaxSizeMB} MB.";
                return false;
            }
            return true;
        }
    }
}
