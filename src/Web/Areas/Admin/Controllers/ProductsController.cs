using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Interfaces;
using Web.Areas.Admin.Models;
using Web.Areas.Admin.Services;

namespace Web.Areas.Admin.Controllers
{
    public class ProductsController : AdminBaseController
    {
        private readonly IProductsViewModelService _productsViewModelService;
        private readonly INewProductViewModelService _newProductViewModelService;
        private readonly IRepository<Product> _productRepository;
        private readonly IWebHostEnvironment _env;
        private readonly PhotoService _photoService;
        private readonly IEditProductViewModelService _editProductViewModelService;

        public ProductsController(IProductsViewModelService productsViewModelService,INewProductViewModelService newProductViewModelService,
            IRepository<Product> productRepository, IWebHostEnvironment env, PhotoService photoService, IEditProductViewModelService editProductViewModelService)
        {
            _productsViewModelService = productsViewModelService;
            _newProductViewModelService = newProductViewModelService;
            _productRepository = productRepository;
            _env = env;
            _photoService = photoService;
            _editProductViewModelService = editProductViewModelService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _productsViewModelService.GetProductsViewModelAsync());
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return NotFound();
            _photoService.DeletePhoto(product.PictureUri);
            await _productRepository.DeleteAsync(product);
            return RedirectToAction("Index", new {message = "deleted"});
        }

        public async Task<IActionResult> New()
        {
            return View(await _newProductViewModelService.GetNewProductViewModelAsync());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> New(NewProductViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product()
                {
                    BrandId = (int)vm.BrandId,
                    CategoryId = (int)vm.CategoryId,
                    StyleId = (int)vm.StyleId,
                    Description = vm.ProductDescription,
                    DiscountRate = (int)vm.ProductDiscountRate,
                    Name = vm.ProductName,
                    Price = (decimal)vm.ProductPrice,  
                    PictureUri = _photoService.SavePhoto(vm.ProductImage),
                    SalesQuantity = (int)vm.ProductSalesQuantity,
                    StockQuantity = (int)vm.ProductStockQuantity,
                };
                await _productRepository.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(await _newProductViewModelService.GetNewProductViewModelAsync());
        }

        public async Task<IActionResult> Edit(int id)
        {
            var editProductViewModel = await _editProductViewModelService.GetEditProductViewModelAsync(id);
            if (editProductViewModel == null) return NotFound();
            return View(editProductViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProductViewModel vm)
        {
            var product = await _productRepository.GetByIdAsync(vm.Id);
            if (product == null) return NotFound();

            if (ModelState.IsValid)
            {
                product.Name = vm.ProductName;
                product.Description = vm.ProductDescription;
                product.Price = (decimal)vm.ProductPrice;
                if (vm.ProductImage != null)
                {
                    _photoService.DeletePhoto(vm.ProductPictureUri);
                    product.PictureUri = _photoService.SavePhoto(vm.ProductImage);
                }
                product.CategoryId = (int)vm.CategoryId;
                product.BrandId = (int)vm.BrandId;
                product.StyleId = (int)vm.StyleId;
                product.CreatedTime = DateTime.Now;
                product.DiscountRate = (int)vm.ProductDiscountRate;
                product.SalesQuantity = (int)vm.ProductSalesQuantity;
                product.StockQuantity = (int)vm.ProductStockQuantity;
                 
                await _productRepository.UpdateAsync(product);

                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
    }
}
