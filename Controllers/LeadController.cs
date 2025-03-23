﻿using Crm_CSharp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Crm_CSharp.Controllers;

public class LeadController : Controller
{
    private readonly LeadService _leadService;

    public LeadController(LeadService leadService)
    {
        _leadService = leadService;
    }
    
    public async Task<IActionResult> Index()
    {
        var leads = await _leadService.GetAllLeadsAsync();
        return View(leads);
    }
    
}