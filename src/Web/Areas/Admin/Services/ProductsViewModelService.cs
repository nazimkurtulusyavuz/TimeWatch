using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Interfaces;
using Web.Areas.Admin.Models;

namespace Web.Areas.Admin.Services
{
    public class ProductsViewModelService : IProductsViewModelService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductsViewModelService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductsViewModel> GetProductsViewModelAsync()
        {
            var specProductsWithCategoryStyleAndBrand = new ProductsFilterSpecification();
            var allProducts = await _productRepository.ListAsync(specProductsWithCategoryStyleAndBrand);

            var vm = new ProductsViewModel()
            {
                Products = allProducts,
            };
            return vm;
        }
    }
}
