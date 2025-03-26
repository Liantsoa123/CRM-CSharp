using Crm_CSharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crm_CSharp.Controllers;

public class ImportController : Controller
{
    private readonly ImportService _importService;

    public ImportController(ImportService importService)
    {
        _importService = importService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Import(IFormFile jsonFile)
    {
        if (jsonFile == null || !jsonFile.FileName.EndsWith(".json"))
        {
            TempData["Error"] = "Veuillez sélectionner un fichier JSON valide";
            return RedirectToAction("Index");
        }

        var result = await _importService.ImportJsonFileAsync(jsonFile);
        
        if (result)
        {
            TempData["Message"] = "Importation réussie";
        }
        else
        {
            TempData["Error"] = "Erreur lors de l'importation";
        }

        return RedirectToAction("Index");
    }
}