using ArticleBlog.DAL.Context;
using ArticleBlog.DAL.Repositories.Abstracts;
using ArticleBlog.DAL.Repositories.Concreates;
using ArticleBlog.DAL.UnitOfWorks;
using Castle.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.DAL.Extentions
{
  
    public static class DataLayerExtention
    {
        public static IServiceCollection AddScopedDAL(this IServiceCollection services)
        {
            services.AddDbContext<BlogDBContext>(options =>     
            {
                string connectionBlogDB = @"Server=DESKTOP-6EM38CB\SQL2022; Database=BlogDBContext; Trusted_Connection=True;";
                options.UseSqlServer(connectionBlogDB);
              
            });

           services.AddDbContext<BlogDBContext>()
                   .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                   .AddScoped<IUnitOfWork,UnitOfWork>(); 





            services.AddDbContext<IdentityDBContext>(options =>     
            {
                string connectionIdentityDB = @"Server=DESKTOP-6EM38CB\SQL2022; Database=IdentityDBContext; Trusted_Connection=True;";
                options.UseSqlServer(connectionIdentityDB);
                
            });

            return services;
        }
    }
}
