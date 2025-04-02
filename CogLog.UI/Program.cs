using CogLog.UI.Contracts;
using CogLog.UI.Middleware;
using CogLog.UI.Services;
using CogLog.UI.Services.Base;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpContextAccessor();

builder.Services.AddRouting(opts => opts.LowercaseUrls = true);

builder.Services.Configure<CookiePolicyOptions>(options =>
    options.MinimumSameSitePolicy = SameSiteMode.None
);

builder
    .Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/auth/login");
        options.AccessDeniedPath = new PathString("/auth/forbidden");
    });

builder.Services.AddTransient<IAuthService, AuthService>();

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IClient, Client>(client =>
    client.BaseAddress = new Uri(builder.Configuration.GetSection("ApiUrl").Value ?? string.Empty)
);
builder.Services.AddScoped<IWordService, WordService>();

builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCookiePolicy();
app.UseAuthentication();

app.UseRouting();
app.UseMiddleware<RequestMiddleware>();

app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Words}/{action=Index}/{id?}");
app.Run();
