using Microsoft.AspNetCore.Mvc;
using Vonavulary.App.Contracts.Identity;
using Vonavulary.App.Models.Identity;

namespace Vonavulary.UI.Controllers.API;

[Route("api/auth")]
[ApiController]
public class AuthApiController(IAuthService authenticationService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
    {
        return Ok(await authenticationService.Login(request));
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
    {
        return Ok(await authenticationService.Register(request));
    }
}
