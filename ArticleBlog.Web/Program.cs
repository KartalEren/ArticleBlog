using ArticleBlog.DAL.Context;
using Microsoft.EntityFrameworkCore;
using ArticleBlog.DAL.Extentions;
using ArticleBlog.BLL.Extensions;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation(); //Projeyi kapatýp açmadan sadece sayfayý yenileyerek index içerisindeki deðiþiklikleri yansýtan uygulamadýr. Ama önce Web katmanýna RazorRuntimeCompilation nuget ýný yüklemek gerekmektedir.

builder.Services.AddScopedDAL(); // DAL içerisindeki Extensions klasöründe DataLayerExtention da Dependency Injection iþlemini AddScopeDAL metodu ile yapmýþ olduk.
// Add services to the container.
builder.Services.AddScopedBLL();// BLL içerisindeki Extensions klasöründe ServiceLayerExtention da Dependency Injection iþlemini AddScopeBLL metodu ile yapmýþ olduk.



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

app.UseEndpoints(endpoints => //Name ve areaName i admin olan cotrollerý Home olan  action olarak da Index e yönlendiren bir endpoints oluþturduk.
{
    endpoints.MapAreaControllerRoute(
     name:"Admin",
     areaName:"Admin",
     pattern:"Admin/{controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapDefaultControllerRoute();//Eðer ki Admin vs deðil de öyle bir þey yazmazsak Default olarak Home-Index e yönlendirilmesi için bunu yazdýk. Kod sýralamasý gereði tüm þartlarý arayarak kodu çalýþtýrýr hangisi çalýþýrsa onu açar.
});

app.Run();
