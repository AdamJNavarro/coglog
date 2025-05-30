using Microsoft.AspNetCore.Mvc;
using Vonavulary.UI.Contracts;
using Vonavulary.UI.Models;
using Vonavulary.UI.Models.Auth;

namespace Vonavulary.UI.Controllers;

public class AuthController(IAuthService _authService) : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVm login)
    {
        if (ModelState.IsValid)
        {
            var isLoggedIn = await _authService.AuthenticateAsync(login.Email, login.Password);
            if (isLoggedIn)
                return LocalRedirect("~/");
        }

        ModelState.AddModelError("", "Log In Attempt Failed. Please try again.");
        return View(login);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _authService.Logout();
        return LocalRedirect("~/");
    }

    public IActionResult Forbidden()
    {
        return View();
    }
}
