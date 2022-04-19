using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperbillCompanion.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperbillCompanion.Controllers
{
    [Authorize]
    public class DitteController : Controller
    {
        readonly SuperbillClient _superbill;
        public DitteController(SuperbillClient superbill)
        {
            _superbill = superbill;
        }
        public async Task<IActionResult> Index()
        {
            if (!Request.Cookies.ContainsKey("API_KEY"))
            {
                return RedirectToAction("Settings", "Home");
            }

            string apiKey = Request.Cookies["API_KEY"];
            string tenantId = Request.Cookies["TENANT_KEY"];
            var ditte = await _superbill.GetDitteAsync(new Models.RequestViewModel
            {
                ApiKey = apiKey,
                TenantId = tenantId
            });

            return View(ditte.OrderBy(d => d.Descrizione));
        }
    }
}
