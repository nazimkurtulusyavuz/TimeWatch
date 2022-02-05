using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Interfaces;
using Web.Areas.Admin.Models;

namespace Web.Areas.Admin.Services
{
    public class NewProductViewModelService : INewProductViewModelService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Style> _styleRepository;
        private readonly IRepository<Brand> _brandRepository;

        public NewProductViewModelService(IRepository<Category> categoryRepository, IRepository<Style> styleRepository,
            IRepository<Brand> brandRepository)
        {
            _categoryRepository = categoryRepository;
            _styleRepository = styleRepository;
            _brandRepository = brandRepository;
        }
        public async Task<NewProductViewModel> GetNewProductViewModelAsync()
        {
            var categories = await _categoryRepository.ListAllAsync();
            var categoriesAsSelectListItem = categories.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
            var styles = await _styleRepository.ListAllAsync();
            var stylesAsSelectListItem = styles.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
            var brands = await _brandRepository.ListAllAsync();
            var brandsAsSelectListItem = brands.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
            var vm = new NewProductViewModel()
            {
                Categories = categoriesAsSelectListItem,
                Styles = stylesAsSelectListItem,
                Brands = brandsAsSelectListItem,
            };
            return vm;
        }
    }
}
