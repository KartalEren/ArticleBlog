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
})//Buraya TIKLANMA SAYISINI BULAB�LMEK ���N WEB-FILTER-ARTICLEVISITORS-ArticleVisitorFilter FilterAction u ekledik (KULLANICI B�LG�LER�N� KAYIT ALTINA ALAB�LMEK ���N BU F�LTER I YAPTIK.)****
                .AddRazorRuntimeCompilation(); //Projeyi kapat�p a�madan sadece sayfay� yenileyerek index i�erisindeki de�i�iklikleri yans�tan uygulamad�r. Ama �nce Web katman�na RazorRuntimeCompilation nuget �n� y�klemek gerekmektedir.


builder.Services.AddScopedDAL(); // DAL i�erisindeki Extensions klas�r�nde DataLayerExtention da Dependency Injection i�lemini AddScopeDAL metodu ile yapm�� olduk.
// Add services to the container.
builder.Services.AddScopedBLL();// BLL i�erisindeki Extensions klas�r�nde ServiceLayerExtention da Dependency Injection i�lemini AddScopeBLL metodu ile yapm�� olduk.
builder.Services.AddSession();// Session eklemek i�in bu metodu buraya tan�mlamal�y�z ve a�a��da da app.UseSession(); metodunu eklemeliyiz ki bu metodu kullanal�m.Cookie eklemek i�in yapt�k.

builder.Services.AddIdentity<AppUser, AppRole>(opt =>//cookie yap�s�n� olu�turuyoruz. Ayr�ca sadece bu ifadeyi (builder.Services.AddIdentity<AppUser, AppRole>) REG�STER ���NDE EKLEMEK GEREKL�D�R.
{
    opt.Password.RequireNonAlphanumeric = false; // sadece b�y�k k���k harf vs duyar�l���n� kald�rmak i�in buray� false yapar�z ve sadece 1234 �ifresiyle giri� yapabiliriz. Bunlar� ger�ek projede kald�r�rsak olu�turulacak �ifre daha g�venli olur.
    opt.Password.RequireLowercase = false; //k���k harf zorunlulu�unu kald�r�r�z. Bunlar� ger�ek projede kald�r�rsak olu�turulacak �ifre daha g�venli olur.
    opt.Password.RequireUppercase = false; ////k���k harf zorunlulu�unu kald�r�r�z. Bunlar� ger�ek projede kald�r�rsak olu�turulacak �ifre daha g�venli olur.
})
    .AddRoleManager<RoleManager<AppRole>>() //role manager olu�turduk. RoleManager � kendi olu�turdu�umuz AppRole den al�yoruz.
    .AddEntityFrameworkStores<IdentityDBContext>() //role un bulundu�u dbcontexti ekledik
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Admin/Authorize/Login"); //admin panele girmek isterse yukar�daki path yoluna admin yolunu yazsa bile giri� yapt�rmak i�in s�rekli login ekran�na y�n�endirecektir.
    config.LogoutPath = new PathString("/Admin/Authorize/Logout");
    config.Cookie = new CookieBuilder//art�k Cookilerimizi olu�turuyoruz.
    {
        Name = "ArticleBlog",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest //http uzant�l� yerlerden istek alabilir.
    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan= TimeSpan.FromDays(1);//Cookienin ne kadar aktif s�re olaca��n� gireriz. Yani oturumun a��k kalma s�residir tekrar login yapmaya gerek yoktur ��k�� yapmadan kapatt���m�z s�rece 1 g�n belirledik.
    config.AccessDeniedPath = new PathString("/Admin/Authorize/AccessDenied");//yetkisiz ki�ilerin oturumunu engellemek i�in kullan�l�r. Super adminden ba�ka ki�inin bir�ey silmesini istemiyorsak (adminin mesela) o i�lemi yapt���nda superadminden yetki istemesi i�in uyar� vermesini sa�lam�� oluruz.
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

app.UseSession();//seesion kullanmak i�in bunu buraya eklemeliyiz.

app.UseRouting();


app.UseAuthentication();//burada role i�in giri� yaparken bilgileri do�rulama yapmak ad�na eklemi� olduk. Bunun app.UseAuthorization(); �st�nde kalmas� gereklidir. ��nk� login oldu�u bilgisini �nce vermemiz gereklidir.
app.UseAuthorization();

app.UseEndpoints(endpoints => //Name ve areaName i admin olan cotroller� Home olan  action olarak da Index e y�nlendiren bir endpoints olu�turduk.
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
    //endpoints.MapDefaultControllerRoute();//E�er ki Admin vs de�il de �yle bir �ey yazmazsak Default olarak Home-Index e y�nlendirilmesi i�in bunu yazd�k. Kod s�ralamas� gere�i t�m �artlar� arayarak kodu �al��t�r�r hangisi �al���rsa onu a�ar.
});

app.Run();
