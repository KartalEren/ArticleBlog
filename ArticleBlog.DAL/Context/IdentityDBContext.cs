using ArticleBlog.DAL.Configuration;
using ArticleBlog.Entitiy.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.DAL.Context
{
    public class IdentityDBContext : IdentityDbContext<AppUser, AppRole, int>
    { 
        //1. Database(BlogDBContext) tablolarımız için klasik bildiğimiz yöntemden gittik(tüm DBSetleri vs oluşturup ayağa kaldırdık, ve OnModelCreating içine Configurationları yazdık.) Ama Package Manager Console a yazdığımız ifade farklıdır kalsör içinde nasıl ne yazılacağı TXT Dosyasında mevcuttur kontrol edersin. 

        //2. Database tablolarını oluştururken aşağıdaki yöndergeleri yapmalıyız.

        //YÖNDERGE-1***Identity için DBSet yapmamıza gerek yoktur. Bunu Identity sınıfından alıyor zaten otomatik olarak.
        public IdentityDBContext(DbContextOptions<IdentityDBContext> opt) : base(opt)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //YÖNDERGE-2***Çift DB Tablolarını OnModelCreating içine yazmaktansa önce bunu yazmalıyız sonra aşağıdaki tüm tabloları otomatik birleiştiren yapıyı yazarız. Burada sadece bu ifade kalsa yeter.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //YÖNDERGE-3***Burada tüm DBSetleri otomatik yapması için de  modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); yapısını kullandık

        }
    }
}
