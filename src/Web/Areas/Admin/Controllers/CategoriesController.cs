using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Controllers
{
    public class CategoriesController : AdminBaseController
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoriesController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _categoryRepository.ListAllAsync());
        }
        public async Task<IActionResult> New()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> New(string name)
        {
            Category category = new Category()
            {
                Name = name,
            };
            await _categoryRepository.AddAsync(category);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return NotFound();
            await _categoryRepository.DeleteAsync(category);
            return RedirectToAction(nameof(Index), new { message = "deleted" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            var categoryTobeEdited = await _categoryRepository.GetByIdAsync(category.Id);
            if (categoryTobeEdited == null) return NotFound();
            categoryTobeEdited.Name = category.Name;
            await _categoryRepository.UpdateAsync(categoryTobeEdited);
            return RedirectToAction(nameof(Index));
        }
    }
}
