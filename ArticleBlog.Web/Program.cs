using ArticleBlog.DAL.Context;
using Microsoft.EntityFrameworkCore;
using ArticleBlog.DAL.Extentions;
using ArticleBlog.BLL.Extensions;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation(); //Projeyi kapat�p a�madan sadece sayfay� yenileyerek index i�erisindeki de�i�iklikleri yans�tan uygulamad�r. Ama �nce Web katman�na RazorRuntimeCompilation nuget �n� y�klemek gerekmektedir.

builder.Services.AddScopedDAL(); // DAL i�erisindeki Extensions klas�r�nde DataLayerExtention da Dependency Injection i�lemini AddScopeDAL metodu ile yapm�� olduk.
// Add services to the container.
builder.Services.AddScopedBLL();// BLL i�erisindeki Extensions klas�r�nde ServiceLayerExtention da Dependency Injection i�lemini AddScopeBLL metodu ile yapm�� olduk.



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

app.UseEndpoints(endpoints => //Name ve areaName i admin olan cotroller� Home olan  action olarak da Index e y�nlendiren bir endpoints olu�turduk.
{
    endpoints.MapAreaControllerRoute(
     name:"Admin",
     areaName:"Admin",
     pattern:"Admin/{controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapDefaultControllerRoute();//E�er ki Admin vs de�il de �yle bir �ey yazmazsak Default olarak Home-Index e y�nlendirilmesi i�in bunu yazd�k. Kod s�ralamas� gere�i t�m �artlar� arayarak kodu �al��t�r�r hangisi �al���rsa onu a�ar.
});

app.Run();
