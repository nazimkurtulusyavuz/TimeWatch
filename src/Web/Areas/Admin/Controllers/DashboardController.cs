using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Interfaces;

namespace Web.Areas.Admin.Controllers
{
    public class DashboardController : AdminBaseController
    {
        private readonly IDashboardViewModelService _dashboardViewModelService;

        public DashboardController(IDashboardViewModelService dashboardViewModelService)
        {
            _dashboardViewModelService = dashboardViewModelService;
        }
        public async Task<IActionResult> Index()
        { 
            return View(await _dashboardViewModelService.GetDashboardViewModelAsync());
        }
    }
}
