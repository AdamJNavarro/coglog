using System.Text;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

using Vonavulary.App;
using Vonavulary.Identity;
using Vonavulary.Persistence;
using Vonavulary.UI.Contracts;
using Vonavulary.UI.Middleware;
using Vonavulary.UI.Services;
using Vonavulary.UI.Services.Base;

var builder = WebApplication.CreateBuilder(args);

// FROM API
builder.Services.AddAppServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddCors(opts =>
    opts.AddPolicy("All", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
);

// CUSTOM.
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddScoped<IWordService, WordService>();
builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();

// HTTP
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient<IClient, Client>(client =>
    client.BaseAddress = new Uri(builder.Configuration.GetSection("ApiUrl").Value ?? string.Empty)
);

// AUTH
var jwtConfig = builder.Configuration.GetSection("JwtSettings");
var jwtKey = jwtConfig["Key"];

builder
    .Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie(
        CookieAuthenticationDefaults.AuthenticationScheme,
        options =>
        {
            options.LoginPath = new PathString("/auth/login");
            options.AccessDeniedPath = new PathString("/auth/forbidden");
        }
    )
    .AddJwtBearer(
        JwtBearerDefaults.AuthenticationScheme,
        options =>
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = jwtConfig["Issuer"],
                ValidAudience = jwtConfig["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey ?? throw new InvalidOperationException("JWT Key is not configured"))),
            }
    );

builder.Services.AddAuthorization(options =>
{
    // Default policy uses cookie authentication
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
        .Build();

    // API policy uses JWT authentication
    options.AddPolicy(
        "ApiPolicy",
        new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
            .Build()
    );
});

builder.Services.Configure<CookiePolicyOptions>(options =>
    options.MinimumSameSitePolicy = SameSiteMode.None
);

// ROUTING
builder.Services.AddRouting(opts => opts.LowercaseUrls = true);

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer(); // API
builder.Services.AddSwaggerGen(opts =>
    opts.DocInclusionPredicate(
        (docName, apiDesc) =>
            apiDesc.RelativePath != null
            && apiDesc.RelativePath.StartsWith("api", StringComparison.InvariantCultureIgnoreCase)
    )
); // API

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // API
    app.UseSwaggerUI(); // API
    app.UseDeveloperExceptionPage();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/words/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCookiePolicy();
app.UseAuthentication();

app.UseRouting();

app.UseMiddleware<CustomMiddleware>();

app.UseAuthorization();

app.UseCors("All"); //  API

app.MapControllerRoute(name: "default", pattern: "{controller=Words}/{action=Index}/{id?}");

app.Run();
