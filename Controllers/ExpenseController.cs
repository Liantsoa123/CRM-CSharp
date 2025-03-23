using Microsoft.AspNetCore.Mvc;
using Crm_CSharp.Models;
using Crm_CSharp.Services;
using HostingEnvironmentExtensions = Microsoft.AspNetCore.Hosting.HostingEnvironmentExtensions;

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

        public async Task<IActionResult> Edit(long id, string source)
        {
            var expense = await _expenseService.GetExpenseByIdAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            
            ViewData["Source"] = source;
            return View("Form", expense);
        }
        
        public async Task<IActionResult> Update(Expense expense, string source)
        {
            var updatedExpense = await _expenseService.UpdateExpenseAsync(expense.ExpenseId, expense);
            
            if (updatedExpense != null)
            {
                TempData["Message"] = "Montant mise à jour avec succès";
                
                // Redirection en fonction de la source
                if (source == "ticket")
                {
                    return RedirectToAction("Index", "Ticket");
                }
                else if (source == "lead")
                {
                    return RedirectToAction("Index", "Lead");
                }
            }
            ModelState.AddModelError("", "Erreur lors de la mise à jour de la dépense");
            return View("Form", expense);
        }
        
    }
}