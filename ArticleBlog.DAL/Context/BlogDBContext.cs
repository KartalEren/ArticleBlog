using ArticleBlog.DAL.Configuration;
using ArticleBlog.Entitiy.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.DAL.Context
{
    //***Çift database ayağa kaldırırken işlemler biraz farklıdır. 1. Database(BlogDBContext) tablolarımız için klasik bildiğimiz yöntemden gittik(tüm DBSetleri vs oluşturup ayağa kaldırdık, ve OnModelCreating içine Configurationları yazdık.) Ama Package Manager Console a yazdığımız ifade farklıdır kalsör içinde nasıl ne yazılacağı TXT Dosyasında mevcuttur kontrol edersin. 
    public class BlogDBContext : DbContext
    {
        public BlogDBContext()
        {

        }

        public BlogDBContext(DbContextOptions<BlogDBContext> options) : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<ArticleVisitor> ArticleVisitors { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Article>(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration<Image>(new ImageConfiguration());
            modelBuilder.ApplyConfiguration<ArticleVisitor>(new ArticleVisitorConfiguration());
        }

    }
}
