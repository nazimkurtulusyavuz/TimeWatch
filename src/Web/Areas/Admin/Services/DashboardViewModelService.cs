using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Interfaces;
using Web.Areas.Admin.Models;

namespace Web.Areas.Admin.Services
{
    public class DashboardViewModelService : IDashboardViewModelService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Brand> _brandRepository;
        private readonly IRepository<Style> _styleRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardViewModelService(IRepository<Product> productRepository, IRepository<Category> categoryRepository, IRepository<Brand> brandRepository, IRepository<Style> styleRepository, IRepository<Order> orderRepository, UserManager<ApplicationUser> userManager)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _styleRepository = styleRepository;
            _orderRepository = orderRepository;
            _userManager = userManager;
        }
        public async Task<DashboardViewModel> GetDashboardViewModelAsync()
        {
            var allProducts = await _productRepository.ListAllAsync();
            var productCount = allProducts.Count();

            var allCategories = await _categoryRepository.ListAllAsync();
            var categoryCount = allCategories.Count();

            var allBrands = await _brandRepository.ListAllAsync();
            var brandCount = allBrands.Count();

            var allStyles = await _styleRepository.ListAllAsync();
            var styleCount = allStyles.Count();

            var allUsers = _userManager.Users;
            var userCount = allUsers.Count();

            var allOrders = await _orderRepository.ListAllAsync();
            var orderCount = allOrders.Count();

            var vm = new DashboardViewModel()
            {
                ProductCount = productCount,
                CategoryCount = categoryCount,
                BrandCount = brandCount,
                StyleCount = styleCount,
                UserCount = userCount,
                OrderCount = orderCount,
            };
        return vm;
        }
    }
}
