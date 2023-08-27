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
    //***Dependency Injection için bu sınıfı kullanırız.
    public static class DataLayerExtention
    {
        public static IServiceCollection AddScopedDAL(this IServiceCollection services)
        {
            services.AddDbContext<BlogDBContext>(options =>     //1. Database (BlogDB) için SQL bağlantı yolu
            {
                string connectionBlogDB = @"Server=DESKTOP-6EM38CB\SQL2022; Database=BlogDBContext; Trusted_Connection=True;";
                options.UseSqlServer(connectionBlogDB);
                //options.UseLazyLoadingProxies();
            });

           services.AddDbContext<BlogDBContext>()
                   .AddScoped(typeof(IRepository<>), typeof(Repository<>)) //Buradaki sınıflar (IRepository ve Repository) jenerik yapıldığı için bu sınıfların başında typeof kullanmak gereklidir.
                   .AddScoped<IUnitOfWork,UnitOfWork>(); //Buradaki IUnitOfWork ve UnitOfWork class larını da mapleme işlemini yapmamız gerekir.
                                                          //NOT: Hangi class larda hem abstract hem de concreate classını açarsak onu da burada belirtmemiz gereklidir.





            services.AddDbContext<IdentityDBContext>(options =>     //2. Database (IdentityDB) için SQL bağlantı yolu
            {
                string connectionIdentityDB = @"Server=DESKTOP-6EM38CB\SQL2022; Database=IdentityDBContext; Trusted_Connection=True;";
                options.UseSqlServer(connectionIdentityDB);
                //options.UseLazyLoadingProxies();
            });

            return services;
        }
    }
}
