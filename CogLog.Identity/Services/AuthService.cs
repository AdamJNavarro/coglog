using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CogLog.App.Contracts.Identity;
using CogLog.App.Exceptions;
using CogLog.App.Models.Identity;
using CogLog.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CogLog.Identity.Services;

public class AuthService(
    UserManager<AppUser> userManager,
    IOptions<JwtSettings> jwtSettings,
    SignInManager<AppUser> signInManager
) : IAuthService
{
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;

    public async Task<AuthResponse> Login(AuthRequest request)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            throw new NotFoundException($"User with {request.Email} not found.", request.Email);
        }

        var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (result.Succeeded == false)
        {
            throw new BadRequestException($"Credentials for '{request.Email} aren't valid'.");
        }

        JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

        var response = new AuthResponse
        {
            Id = user.Id,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Email = user.Email,
        };

        return response;
    }

    public async Task<RegistrationResponse> Register(RegistrationRequest request)
    {
        if (request.Email != "adamjnav@gmail.com")
        {
            throw new BadRequestException("Invalid email address.");
        }

        var user = new AppUser() { Email = request.Email, EmailConfirmed = true };

        var result = await userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Guest");
            return new RegistrationResponse() { UserId = user.Id };
        }
        else
        {
            var str = new StringBuilder();
            foreach (var err in result.Errors)
            {
                str.Append($"•{err.Description}\n");
            }

            throw new BadRequestException($"{str}");
        }
    }

    private async Task<JwtSecurityToken> GenerateToken(AppUser user)
    {
        var userClaims = await userManager.GetClaimsAsync(user);
        var roles = await userManager.GetRolesAsync(user);

        var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id),
        }
            .Union(userClaims)
            .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtSettings.Key)
        );

        var signingCredentials = new SigningCredentials(
            symmetricSecurityKey,
            SecurityAlgorithms.HmacSha256
        );

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredentials
        );

        return jwtSecurityToken;
    }
}
