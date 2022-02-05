using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Attributes;

namespace Web.Areas.Admin.Models
{
    public class EditProductViewModel
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }        

        [ProductImage(MaxSizeMB = 0.2d)]
        public IFormFile ProductImage { get; set; }

        [Required]
        public string ProductPictureUri { get; set; }


        [Required]
        public int? CategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; }

        [Required]
        public int? StyleId { get; set; }

        public List<SelectListItem> Styles { get; set; }

        [Required]
        public int? BrandId { get; set; }

        public List<SelectListItem> Brands { get; set; }

        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int? ProductSalesQuantity { get; set; }

        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int? ProductStockQuantity { get; set; }

        [Required]   
        [Range(0, 99, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? ProductDiscountRate { get; set; }

        [Required, ProductPrice]
        public decimal? ProductPrice { get; set; }    

        [Required]
        public string ProductDescription { get; set; }
    }
}
