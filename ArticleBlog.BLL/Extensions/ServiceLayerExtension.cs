﻿using ArticleBlog.BLL.Services.Abstract;
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
using FluentValidation;
using ArticleBlog.BLL.FluentValidations;
using FluentValidation.AspNetCore;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using ArticleBlog.BLL.Helpers.Images;

namespace ArticleBlog.BLL.Extensions
{
    //****BURADA SEVİSTEKİ METOTLARIMI ÇAĞIRMAK İÇİN OLUŞTURDUĞUM INTERFACE CLASSLARLA CLASSLARIN NORMAL SINIFINI MAPLİYORUM. DEPENDENCY EXTENSION YAPILDI.


    //Burada da MVC.Web kısmında programı çalıştırırken Referansı BLL den aldığı için program hata vermemesi adına burada da DAL kısmında yaptığımız mapper tarzı işlemi yapmalıyız hangi sınıfta işlemler yapacaksak.
    public static class ServiceLayerExtension //Her seferinde new lenmeyeceği için static calss yapılır.
    {

        public static IServiceCollection AddScopedBLL(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly(); //BLL deki tüm assembly edilecek dosyaları tek tek yazmak yerine bu değişkeni oluştururuz. ve eğer ki auto mapper ekleyeceksek aşağıdaki gibi services.AddAutoMapper(assembly); tanımlarsak assembly değişkenindeki GetExecutingAssembly metodu sayesinde tüm işleri kendi yapar bu katmandaki Auto mapperları kendisi kurar(Profile dan verdiğimiz kalıtımlar sayaesinde kendi bulur burada automapper var der ve kendiliğinden ekler tüm sınıflar için.)

            services.AddScopedDAL().AddScoped<IArticleService, ArticleService>(); //IArticleService çağırıldığında ArticleService döneceğini bildirir.
            services.AddScopedDAL().AddScoped<ICategoryService, CategoryService>(); //ICategoryService çağırıldığında CategoryService döneceğini bildirir.
            services.AddScopedDAL().AddScoped<IUserService, UserService>(); //IUserService çağırıldığında UserService döneceğini bildirir.
            services.AddScoped<IImageHelper, ImageHelper>(); //IImageHelper çağırıldığında ImageHelper döneceğini bildirir.

            services.AddAutoMapper(assembly);//BLL katmanıdaki tüm automapper kurulan yapıları bulup (Profile dan kalıtım alan dosyaları)
                                            


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//BLL-Extension-LoggedInUserExtensions deki ifadeleri görmesi için buraya servis ekledik. HttpContextAccessor ile kullanıcıyı bulmamızı sağlayan yapıdır.


            //***Bu yapı için bu katmana Nugget indirdik FluentValidation.NETCORE olanını ve FluentValidationDependecyInjection diye yazanı indirmek gerekiyor.....

            services.AddControllersWithViews()
                .AddFluentValidation(opt =>
                {
                    opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>(); //****ArticleValidatordan kaloıtım alan tüm Validatorler için yapılmış maplemedir tek tek tüm validatorleri girmeye gerek yoktur.
                    opt.DisableDataAnnotationsValidation = true; //dataAnnotation kullanmamak için bunu true yaptık. çünkü FluentValidationla yapacağız BLL-Extension klasöründeki
                    opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("en");
                }); //dil ayarlaması yapılır.

            return services;

        }
    }
}