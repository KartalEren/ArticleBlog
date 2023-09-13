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
using FluentValidation;
using ArticleBlog.BLL.FluentValidations;
using FluentValidation.AspNetCore;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using ArticleBlog.BLL.Helpers.Images;

namespace ArticleBlog.BLL.Extensions
{
   
    public static class ServiceLayerExtension 
    {

        public static IServiceCollection AddScopedBLL(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly(); 

            services.AddScopedDAL().AddScoped<IArticleService, ArticleService>(); 
            services.AddScopedDAL().AddScoped<ICategoryService, CategoryService>();
            services.AddScopedDAL().AddScoped<IUserService, UserService>();
            services.AddScoped<IImageHelper, ImageHelper>(); 

            services.AddAutoMapper(assembly);
                                            


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


           

            services.AddControllersWithViews()
                .AddFluentValidation(opt =>
                {
                    opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>(); 
                    opt.DisableDataAnnotationsValidation = true; 
                    opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("en");
                }); 

            return services;

        }
    }
}