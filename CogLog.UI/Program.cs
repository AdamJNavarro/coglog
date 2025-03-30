using CogLog.App.Constants;
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
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder
    .Services.AddAuthorizationBuilder()
    .AddPolicy(
        AuthConstants.Policies.AdminOnly,
        policy => policy.RequireRole(AuthConstants.Roles.Administrator)
    );

builder
    .Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/auth/login");
    });

builder.Services.AddTransient<IAuthService, AuthService>();

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IClient, Client>(client =>
    client.BaseAddress = new Uri(builder.Configuration.GetSection("ApiUrl").Value ?? string.Empty)
);
builder.Services.AddScoped<IBlockService, BlockService>();

builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ITopicService, TopicService>();

builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();

// builder.Services.AddScoped<IHierarchyIconService, HierarchyIconService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(
    new StaticFileOptions
    {
        OnPrepareResponse = ctx =>
        {
            // Cache SVG files for 7 days
            if (ctx.File.Name.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
            {
                ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=604800");
            }
        },
    }
);

app.UseCookiePolicy();
app.UseAuthentication();

app.UseRouting();
app.UseMiddleware<RequestMiddleware>();

app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Blocks}/{action=Index}/{id?}");
app.Run();
