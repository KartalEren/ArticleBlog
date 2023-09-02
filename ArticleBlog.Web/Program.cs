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
})//Buraya TIKLANMA SAYISINI BULABÝLMEK ÝÇÝN WEB-FILTER-ARTICLEVISITORS-ArticleVisitorFilter FilterAction u ekledik (KULLANICI BÝLGÝLERÝNÝ KAYIT ALTINA ALABÝLMEK ÝÇÝN BU FÝLTER I YAPTIK.)****
                .AddRazorRuntimeCompilation(); //Projeyi kapatýp açmadan sadece sayfayý yenileyerek index içerisindeki deðiþiklikleri yansýtan uygulamadýr. Ama önce Web katmanýna RazorRuntimeCompilation nuget ýný yüklemek gerekmektedir.


builder.Services.AddScopedDAL(); // DAL içerisindeki Extensions klasöründe DataLayerExtention da Dependency Injection iþlemini AddScopeDAL metodu ile yapmýþ olduk.
// Add services to the container.
builder.Services.AddScopedBLL();// BLL içerisindeki Extensions klasöründe ServiceLayerExtention da Dependency Injection iþlemini AddScopeBLL metodu ile yapmýþ olduk.
builder.Services.AddSession();// Session eklemek için bu metodu buraya tanýmlamalýyýz ve aþaðýda da app.UseSession(); metodunu eklemeliyiz ki bu metodu kullanalým.Cookie eklemek için yaptýk.

builder.Services.AddIdentity<AppUser, AppRole>(opt =>//cookie yapýsýný oluþturuyoruz. Ayrýca sadece bu ifadeyi (builder.Services.AddIdentity<AppUser, AppRole>) REGÝSTER ÝÇÝNDE EKLEMEK GEREKLÝDÝR.
{
    opt.Password.RequireNonAlphanumeric = false; // sadece büyük küçük harf vs duyarýlýðýný kaldýrmak için burayý false yaparýz ve sadece 1234 þifresiyle giriþ yapabiliriz. Bunlarý gerçek projede kaldýrýrsak oluþturulacak þifre daha güvenli olur.
    opt.Password.RequireLowercase = false; //küçük harf zorunluluðunu kaldýrýrýz. Bunlarý gerçek projede kaldýrýrsak oluþturulacak þifre daha güvenli olur.
    opt.Password.RequireUppercase = false; ////küçük harf zorunluluðunu kaldýrýrýz. Bunlarý gerçek projede kaldýrýrsak oluþturulacak þifre daha güvenli olur.
})
    .AddRoleManager<RoleManager<AppRole>>() //role manager oluþturduk. RoleManager ý kendi oluþturduðumuz AppRole den alýyoruz.
    .AddEntityFrameworkStores<IdentityDBContext>() //role un bulunduðu dbcontexti ekledik
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Admin/Authorize/Login"); //admin panele girmek isterse yukarýdaki path yoluna admin yolunu yazsa bile giriþ yaptýrmak için sürekli login ekranýna yönþendirecektir.
    config.LogoutPath = new PathString("/Admin/Authorize/Logout");
    config.Cookie = new CookieBuilder//artýk Cookilerimizi oluþturuyoruz.
    {
        Name = "ArticleBlog",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest //http uzantýlý yerlerden istek alabilir.
    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan= TimeSpan.FromDays(1);//Cookienin ne kadar aktif süre olacaðýný gireriz. Yani oturumun açýk kalma süresidir tekrar login yapmaya gerek yoktur çýkýþ yapmadan kapattýðýmýz sürece 1 gün belirledik.
    config.AccessDeniedPath = new PathString("/Admin/Authorize/AccessDenied");//yetkisiz kiþilerin oturumunu engellemek için kullanýlýr. Super adminden baþka kiþinin birþey silmesini istemiyorsak (adminin mesela) o iþlemi yaptýðýnda superadminden yetki istemesi için uyarý vermesini saðlamýþ oluruz.
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

app.UseSession();//seesion kullanmak için bunu buraya eklemeliyiz.

app.UseRouting();


app.UseAuthentication();//burada role için giriþ yaparken bilgileri doðrulama yapmak adýna eklemiþ olduk. Bunun app.UseAuthorization(); üstünde kalmasý gereklidir. Çünkü login olduðu bilgisini önce vermemiz gereklidir.
app.UseAuthorization();

app.UseEndpoints(endpoints => //Name ve areaName i admin olan cotrollerý Home olan  action olarak da Index e yönlendiren bir endpoints oluþturduk.
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
