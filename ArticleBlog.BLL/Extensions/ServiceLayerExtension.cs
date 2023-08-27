using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.BLL.Services.Concreate;
using ArticleBlog.DAL.Context;
using ArticleBlog.DAL.Repositories.Abstracts;
using ArticleBlog.DAL.Repositories.Concreates;
using Microsoft.Extensions.DependencyInjection;
using ArticleBlog.DAL.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ArticleBlog.BLL.Extensions
{
    //Burada da MVC.Web kısmında programı çalıştırırken Referansı BLL den aldığı için program hata vermemesi adına burada da DAL kısmında yaptığımız mapper tarzı işlemi yapmalıyız hangi sınıfta işlemler yapacaksak.
    public static class ServiceLayerExtension
    {
        
        public static IServiceCollection AddScopedBLL(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly(); //BLL deki tüm assembly edilecek dosyaları tek tek yazmak yerine bu değişkeni oluştururuz. ve eğer ki auto mapper ekleyeceksek aşağıdaki gibi services.AddAutoMapper(assembly); tanımlarsak assembly değişkenindeki GetExecutingAssembly metodu sayesinde tüm işleri kendi yapar bu katmandaki Auto mapperları kendisi kurar(Profile dan verdiğimiz kalıtımlar sayaesinde kendi bulur burada automapper var der ve kendiliğinden ekler tüm sınıflar için.)

            services.AddScopedDAL().AddScoped<IArticleService, ArticleService>();

            services.AddAutoMapper(assembly);//BLL katmanıdaki tüm automapper kurulan yapıları bulup (Profile dan kalıtım alan dosyaları) 
            return services;

        }
    }
}