using Microsoft.AspNetCore.Mvc;
using Crm_CSharp.Models;
using Crm_CSharp.Services;

namespace Crm_CSharp.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ExpenseService _expenseService;

        public ExpenseController(ExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        public async Task<IActionResult> Index()
        {
            var expenses = await _expenseService.GetAllExpensesAsync();
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View("Form", new Expense());
        }

        public async Task<IActionResult> Edit(long id)
        {
            var expense = await _expenseService.GetExpenseByIdAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            return View("Form", expense);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Expense expense)
        {

            Expense result;
            if (expense.ExpenseId == 0)
            {
                result = await _expenseService.CreateExpenseAsync(expense);
            }
            else
            {
                result = await _expenseService.UpdateExpenseAsync(expense.ExpenseId, expense);
            }
            
            if (result != null)
            {
                TempData["Message"] = "Dépense enregistrée avec succès";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("Message", "Erreur lors de l'enregistrement de la dépense");
            return View("Form", expense);
        }
    }
}