using Crm_CSharp.Models;
using Crm_CSharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crm_CSharp.Controllers;

public class TicketController : Controller
{
    private readonly TicketService _ticketService;
    
    public TicketController(TicketService ticketService)
    {
        _ticketService = ticketService;
    }
    
    public async Task<IActionResult> Index()
    {
        var tickets = await _ticketService.GetAllTicketsAsync();
        return View(tickets);
    }
    
  
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _ticketService.DeleteTicketAsync(id);
        if (result)
        {
            return RedirectToAction("Index");
        }
        return NotFound();
    }
}