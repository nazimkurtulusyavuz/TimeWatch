using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Interfaces;

namespace Web.Areas.Admin.Controllers
{
    public class OrdersController : AdminBaseController
    {
        private readonly IOrdersViewModelService _ordersViewModelService;

        public OrdersController(IOrdersViewModelService ordersViewModelService)
        {
            _ordersViewModelService = ordersViewModelService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _ordersViewModelService.GetOrderViewModelAsync());
        }
    }
}
