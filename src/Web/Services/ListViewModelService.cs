using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.Models;

namespace Web.Services
{
    public class ListViewModelService : IListViewModelService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Brand> _brandRepository;
        private readonly IRepository<Style> _styleRepository;

        public ListViewModelService(IRepository<Product> productRepository, IRepository<Category> categoryRepository,
            IRepository<Brand> brandRepository, IRepository<Style> styleRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _styleRepository = styleRepository;
        }

        public async Task<ListViewModel> GetListViewModelAsync(string category, string brand, string style, int page)
        {
            var specProducts = new ProductsFilterSpecification(category, brand, style);
            var specProductsPaginated = new ProductsFilterSpecification(category, brand, style, page, Constants.ITEMS_PER_PAGE_LIST);
            int totalProductsCount = await _productRepository.CountAsync(specProducts);
            var productsPaginated = await _productRepository.ListAsync(specProductsPaginated);
            var pi = new PaginationInfoViewModel(totalProductsCount, page, Constants.ITEMS_PER_PAGE_LIST, productsPaginated.Count);

            var list = productsPaginated.Select(x => new ProductViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                PictureUri = x.PictureUri,
                Price = x.Price,
                DiscountRate = x.DiscountRate,
                
            }).ToList();

            var vm = new ListViewModel()
            {
                PaginationInfo = pi,
                Products = list,
                Categories = (await _categoryRepository.ListAllAsync()).Select(x => new SelectListItem(x.Name, x.Name)).ToList(),
                Brands = (await _brandRepository.ListAllAsync()).Select(x => new SelectListItem(x.Name, x.Name)).ToList(),
                Styles = (await _styleRepository.ListAllAsync()).Select(x => new SelectListItem(x.Name, x.Name)).ToList(),
                Category = category ,  
                Brand = brand,   
                Style = style,       
            };
            return vm;
        }
    }
}
