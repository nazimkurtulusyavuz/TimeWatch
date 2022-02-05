using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IListViewModelService _listViewModelService;
        private readonly IHomeViewModelService _homeViewModelService;
        private readonly ISingleProductViewModelService _singlePageViewModelService;

        public HomeController(IListViewModelService listViewModelService, IHomeViewModelService homeViewModelService, ISingleProductViewModelService singlePageViewModelService)
        {
            _listViewModelService = listViewModelService;
            _homeViewModelService = homeViewModelService;
            _singlePageViewModelService = singlePageViewModelService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _homeViewModelService.GetHomeViewModelAsync());
        }

        public async Task<IActionResult> List(string category, string brand, string style, int page = 1)
        {
            return View(await _listViewModelService.GetListViewModelAsync(category, brand, style, page));
        }

        public async Task<IActionResult> SingleProduct(string product)
        {
            return View(await _singlePageViewModelService.GetSingleProductViewModelAsync(product));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
