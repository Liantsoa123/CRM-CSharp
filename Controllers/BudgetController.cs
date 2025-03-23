using Microsoft.AspNetCore.Mvc;
using Crm_CSharp.Services;
using Crm_CSharp.Models;

namespace Crm_CSharp.Controllers;

public class BudgetController : Controller
{
    private readonly BudgetService _budgetService;

    public BudgetController(BudgetService budgetService)
    {
        _budgetService = budgetService;
    }

    public async Task<IActionResult> Index()
    {
        var budgets = await _budgetService.GetBudgetsAsync();
        return View(budgets);
    }
}