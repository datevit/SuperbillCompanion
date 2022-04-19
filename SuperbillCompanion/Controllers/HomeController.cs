using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuperbillCompanion.Models;
using SuperbillCompanion.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SuperbillCompanion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConfigClient _configClient;

        public HomeController(ILogger<HomeController> logger, ConfigClient configClient)
        {
            _logger = logger;
            _configClient = configClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Settings()
        {
            var model = new SettingsViewModel();
            if (Request.Cookies.ContainsKey("API_KEY"))
            {
                model.AuthKey = Request.Cookies["API_KEY"];
                model.TenantId = Request.Cookies["TENANT_KEY"];
            }
            
            model.Tenants = await _configClient.GetMyTenantsAsync();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Settings(SettingsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Tenants = await _configClient.GetMyTenantsAsync();
                return View(model);
            }
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Append("API_KEY", model.AuthKey, option);
            Response.Cookies.Append("TENANT_KEY", model.TenantId, option);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
