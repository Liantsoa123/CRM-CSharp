using CRM_CSharp.Models.AlertRate;
using Crm_CSharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRM_CSharp.Controllers;

public class AlertRateController : Controller
{
    private readonly AlertRateService _alertRateService;

    public AlertRateController(AlertRateService alertRateService)
    {
        _alertRateService = alertRateService;
    }

    public async Task<IActionResult> Index()
    {
        AlertRate alertRate = await _alertRateService.GetAlertRateByIdAsync(1);
        return View( alertRate);
    }

    [HttpPost]
    public async Task<IActionResult> Update(AlertRate alertRate)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", alertRate);
        }

        var updatedRate = await _alertRateService.UpdateAlertRateAsync(alertRate.AlertRateId, alertRate);
        if (updatedRate != null)
        {
            TempData["Message"] = "Taux d'alerte mis à jour avec succès";
            return RedirectToAction("Index");
        }

        ModelState.AddModelError("", "Erreur lors de la mise à jour du taux");
        return View("Index", alertRate);
    }
}