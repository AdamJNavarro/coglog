using System.Reflection;
using CogLog.UI.Contracts;
using CogLog.UI.Services;
using CogLog.UI.Services.Base;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder
    .Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/admin/login");
    });

builder.Services.AddTransient<IAuthService, AuthService>();

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IClient, Client>(client =>
    client.BaseAddress = new Uri(builder.Configuration.GetSection("ApiUrl").Value ?? string.Empty)
);
builder.Services.AddScoped<IBrainBlockService, BrainBlockService>();
builder.Services.AddScoped<ITopicService, TopicService>();
builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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

app.UseRouting();

app.UseAuthorization();
app.UseCookiePolicy();
app.UseAuthentication();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
