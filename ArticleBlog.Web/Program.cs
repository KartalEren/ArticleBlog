using ArticleBlog.DAL.Context;
using Microsoft.EntityFrameworkCore;
using ArticleBlog.DAL.Extentions;
using ArticleBlog.BLL.Extensions;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using ArticleBlog.Entitiy.Entities;
using Microsoft.AspNetCore.Identity;
using ArticleBlog.Web.Filters.ArticleVisitors;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add<ArticleVisitorFilter>();
})
                .AddRazorRuntimeCompilation();


builder.Services.AddScopedDAL(); 
// Add services to the container.
builder.Services.AddScopedBLL();
builder.Services.AddSession();

builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false; 
    opt.Password.RequireLowercase = false; 
    opt.Password.RequireUppercase = false; 
})
    .AddRoleManager<RoleManager<AppRole>>() 
    .AddEntityFrameworkStores<IdentityDBContext>() 
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Admin/Authorize/Login"); 
    config.LogoutPath = new PathString("/Admin/Authorize/Logout");
    config.Cookie = new CookieBuilder
    {
        Name = "ArticleBlog",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest 
    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan= TimeSpan.FromDays(1);
    config.AccessDeniedPath = new PathString("/Admin/Authorize/AccessDenied");
});




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

app.UseSession();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => 
{
    endpoints.MapAreaControllerRoute
    (
        name: "Admin",
        areaName: "Admin", pattern: "Admin/{Controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute
    (
        name: "default", pattern: "{controller=Home}/{action=About}/{id?}"
    );

    endpoints.MapDefaultControllerRoute();



    //endpoints.MapAreaControllerRoute(
    // name:"Admin",
    // areaName:"Admin",
    // pattern:"Admin/{controller=Home}/{action=Index}/{id?}"
    //    );
    //endpoints.MapDefaultControllerRoute();//Eðer ki Admin vs deðil de öyle bir þey yazmazsak Default olarak Home-Index e yönlendirilmesi için bunu yazdýk. Kod sýralamasý gereði tüm þartlarý arayarak kodu çalýþtýrýr hangisi çalýþýrsa onu açar.
});

app.Run();
