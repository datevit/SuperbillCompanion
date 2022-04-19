using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperbillCompanion.Models;
using SuperbillCompanion.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperbillCompanion.Controllers
{
    [Authorize]
    public class DocumentiController : Controller
    {
        readonly SuperbillClient _superbill;
        public DocumentiController(SuperbillClient superbill)
        {
            _superbill = superbill;
        }
        public async Task<IActionResult> Index(int idelemento, int page = 0)
        {
            if (!Request.Cookies.ContainsKey("API_KEY"))
            {
                return RedirectToAction("Settings", "Home");
            }

            string apiKey = Request.Cookies["API_KEY"];
            string tenantId = Request.Cookies["TENANT_KEY"];
            var documenti = await _superbill.GetFattureAsync(new RequestViewModel
            {
                ApiKey = apiKey,
                TenantId = tenantId,
                IdElemento = idelemento
            }, page);

            ViewData["idelemento"] = idelemento;

            return View(documenti);
        }
    }

}
