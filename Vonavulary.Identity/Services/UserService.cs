using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Vonavulary.App.Contracts.Identity;

namespace Vonavulary.Identity.Services;

public class UserService(IHttpContextAccessor contextAccessor) : IUserService
{
    public string UserId => contextAccessor.HttpContext?.User?.FindFirstValue("uid");
}
