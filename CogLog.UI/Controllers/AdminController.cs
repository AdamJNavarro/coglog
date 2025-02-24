using CogLog.UI.Contracts;
using CogLog.UI.Models;
using CogLog.UI.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Controllers;

public class AdminController(IAuthService _authService) : Controller
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
}
