using System.Security.Claims;
using CogLog.App.Contracts.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace CogLog.Identity.Services;

public class UserService(IHttpContextAccessor contextAccessor) : IUserService
{
    public string UserId => contextAccessor.HttpContext?.User?.FindFirstValue("uid");
}
