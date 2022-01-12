using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.Models;

namespace Web.Services
{
    public class SingleProductViewModelService : ISingleProductViewModelService
    {
        private readonly IRepository<Product> _productRepository;

        public SingleProductViewModelService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductViewModel> GetSingleProductViewModelAsync(string name)
        {
            var specSelectedProduct = new SingleProductFilterSpecification(name);
            var selectedProduct = await _productRepository.ListAsync(specSelectedProduct);   

            var vm = selectedProduct.Select(x => new ProductViewModel  
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                PictureUri = x.PictureUri,
                Price = x.Price,
                DiscountRate = x.DiscountRate,
                BrandName = x.Brand.Name,
                CategoryName = x.Category.Name,
                StyleName = x.Style.Name,
                StockQuantity = x.StockQuantity,
            }).FirstOrDefault();
            return vm;
        }
    }
}
