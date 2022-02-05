using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Controllers
{
    public class BrandsController : AdminBaseController
    {
        private readonly IRepository<Brand> _brandRepository;

        public BrandsController(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _brandRepository.ListAllAsync());
        }
        public async Task<IActionResult> New()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> New(string name)
        {
            Brand brand = new Brand()
            {
                Name = name,
            };
            await _brandRepository.AddAsync(brand);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null) return NotFound();
            await _brandRepository.DeleteAsync(brand);
            return RedirectToAction(nameof(Index), new { message = "deleted" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null) return NotFound();
            return View(brand);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Brand brand)
        {
            var brandTobeEdited = await _brandRepository.GetByIdAsync(brand.Id);
            if (brandTobeEdited == null) return NotFound();
            brandTobeEdited.Name = brand.Name;
            await _brandRepository.UpdateAsync(brandTobeEdited);
            return RedirectToAction(nameof(Index));
        }
    }
}
