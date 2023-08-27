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

namespace ArticleBlog.BLL.Extensions
{
    //Burada da MVC.Web kısmında programı çalıştırırken Referansı BLL den aldığı için program hata vermemesi adına burada da DAL kısmında yaptığımız mapper tarzı işlemi yapmalıyız hangi sınıfta işlemler yapacaksak.
    public static class ServiceLayerExtension
    {
        public static IServiceCollection AddScopedBLL(this IServiceCollection services)
        {
            services.AddScopedDAL().AddScoped<IArticleService, ArticleService>();
            return services;

        }
    }
}