using Microsoft.AspNetCore.Mvc;
using Crm_CSharp.Services;
using Crm_CSharp.Models.Statistics;

namespace Crm_CSharp.Controllers;

public class DashboardController : Controller
{
    private readonly CustomerStatisticsDTOService _customerStatisticsService;

    public DashboardController(CustomerStatisticsDTOService customerStatisticsService)
    {
        _customerStatisticsService = customerStatisticsService;
    }

    public async Task<IActionResult> Index()
    {
        var statistics = await _customerStatisticsService.GetCustomerStatisticsAsync();
        return View(statistics);
    }
}