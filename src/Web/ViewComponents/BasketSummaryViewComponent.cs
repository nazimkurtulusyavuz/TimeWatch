using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;

namespace Web.ViewComponents
{
    public class BasketSummaryViewComponent : ViewComponent
    {
        private readonly IBasketViewModelService _basketViewModelService;

        public BasketSummaryViewComponent(IBasketViewModelService basketViewModelService)
        {
            _basketViewModelService = basketViewModelService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _basketViewModelService.GetBasketAsync());
        }
    }
}
