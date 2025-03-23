using Microsoft.AspNetCore.Mvc;
using Crm_CSharp.Services;
using Crm_CSharp.Models;

namespace Crm_CSharp.Controllers;

public class AuthController : Controller
{
    private readonly UserService _userService;

    public AuthController(UserService userService)
    {
        _userService = userService;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email)
    {
        var user = await _userService.GetUserByEmailAsync(email);
        if (user == null)
        {
            ModelState.AddModelError("", "Utilisateur non trouvé");
            return View();
        }
        return RedirectToAction("Index", "Dashboard");
    }
}