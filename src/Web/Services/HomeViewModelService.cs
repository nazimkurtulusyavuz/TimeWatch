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
    public class HomeViewModelService :IHomeViewModelService
    {
        private readonly IRepository<Product> _productRepository;
        public HomeViewModelService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<HomeViewModel> GetHomeViewModelAsync()
        {
            var specProductsMostPopular = new ProductsFilterSpecification("salesQuantity");
            var productsMostPopular = await _productRepository.ListAsync(specProductsMostPopular);
            var mostPopularList = productsMostPopular.Select(x => new ProductViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                PictureUri = x.PictureUri,
                Price = x.Price,
                DiscountRate = x.DiscountRate,
            }).ToList();

            var specProductsAboutToRunOut = new ProductsFilterSpecification("stockQuantity");
            var productsAboutToRunOut = await _productRepository.ListAsync(specProductsAboutToRunOut);
            var aboutToRunOutList = productsAboutToRunOut.Select(x => new ProductViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                PictureUri = x.PictureUri,
                Price = x.Price,
                DiscountRate = x.DiscountRate,
            }).ToList();

            var specMostRecentProducts = new ProductsFilterSpecification("createdTime");
            var productsMostRecent = await _productRepository.ListAsync(specMostRecentProducts);
            var mostRecentList = productsMostRecent.Select(x => new ProductViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                PictureUri = x.PictureUri,
                Price = x.Price,
                DiscountRate = x.DiscountRate,
            }).ToList();

            var specDiscountProducts = new ProductsFilterSpecification("discountRate");
            var productsHaveDiscount = await _productRepository.ListAsync(specDiscountProducts);
            var discounttList = productsHaveDiscount.Select(x => new ProductViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                PictureUri = x.PictureUri,
                Price = x.Price,
                DiscountRate = x.DiscountRate,
            }).ToList();

            var vm = new HomeViewModel()
            {
                MostRecentProducts = mostRecentList,
                MostPopularProducts = mostPopularList,
                AboutToRunOutProducts = aboutToRunOutList,
                DiscountProducts = discounttList,
            };
            return vm;
        }
    }
}
