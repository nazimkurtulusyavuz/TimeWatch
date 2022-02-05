using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Controllers
{
    public class StylesController : AdminBaseController
    {
        private readonly IRepository<Style> _styleRepository;

        public StylesController(IRepository<Style> styleRepository)
        {
            _styleRepository = styleRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _styleRepository.ListAllAsync());
        }
        public async Task<IActionResult> New()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> New(string name)
        {
            Style style = new Style()
            {
                Name = name,
            };
            await _styleRepository.AddAsync(style);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var style = await _styleRepository.GetByIdAsync(id);
            if (style == null) return NotFound();
            await _styleRepository.DeleteAsync(style);
            return RedirectToAction(nameof(Index), new { message = "deleted" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            var style = await _styleRepository.GetByIdAsync(id);
            if (style == null) return NotFound();
            return View(style);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Brand brand)
        {
            var styleTobeEdited = await _styleRepository.GetByIdAsync(brand.Id);
            if (styleTobeEdited == null) return NotFound();
            styleTobeEdited.Name = brand.Name;
            await _styleRepository.UpdateAsync(styleTobeEdited);
            return RedirectToAction(nameof(Index));
        }
    }
}
