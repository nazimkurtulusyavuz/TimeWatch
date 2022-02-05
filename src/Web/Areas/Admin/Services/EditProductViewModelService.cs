using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Interfaces;
using Web.Areas.Admin.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Web.Areas.Admin.Services
{
    public class EditProductViewModelService : IEditProductViewModelService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Brand> _brandRepository;
        private readonly IRepository<Style> _styleRepository;
        private readonly IWebHostEnvironment _env;

        public EditProductViewModelService(IRepository<Product> productRepository, IRepository<Category> categoryRepository, IRepository<Brand> brandRepository, IRepository<Style> styleRepository, IWebHostEnvironment env)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _styleRepository = styleRepository;
            _env = env;
        }
        public async Task<EditProductViewModel> GetEditProductViewModelAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;

            var categories = await _categoryRepository.ListAllAsync();
            var categoriesAsSelectListItem = categories.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
            var styles = await _styleRepository.ListAllAsync();
            var stylesAsSelectListItem = styles.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
            var brands = await _brandRepository.ListAllAsync();
            var brandsAsSelectListItem = brands.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();

            var vm = new EditProductViewModel() 
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                StyleId = product.StyleId,
                ProductDescription = product.Description,
                ProductDiscountRate = product.DiscountRate,
                ProductName = product.Name,
                ProductPrice = product.Price,
                ProductSalesQuantity = product.SalesQuantity,
                ProductStockQuantity = product.StockQuantity,
                Categories = categoriesAsSelectListItem,
                Brands = brandsAsSelectListItem,
                Styles = stylesAsSelectListItem,
                ProductPictureUri = product.PictureUri,
            };
            return vm;
        }
    }
}
