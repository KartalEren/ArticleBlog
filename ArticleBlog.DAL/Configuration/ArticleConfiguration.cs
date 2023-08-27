using ArticleBlog.Entitiy.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.DAL.Configuration
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityColumn(1, 1);

            builder.Property(x => x.Title)
                .HasMaxLength(75);
     

            builder.HasOne(x => x.Category)
               .WithMany(x => x.Articles)
               .HasForeignKey(x => x.CategoryId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Image)
                        .WithMany(x => x.Articles)
                        .HasForeignKey(x => x.ImageId)
                        .OnDelete(DeleteBehavior.NoAction);


            builder.HasData(new Article
            {
                ID = 1,
                Title = "Article",
                Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                ViewCount = 15,
                CategoryId = 1,
                ImageId = 1,
                CreatedBy = "Umut Oncel",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            }, new Article
            {
                ID = 2,
                Title = "Article",
                Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                ViewCount = 50,
                CategoryId = 2,
                ImageId = 2,
                CreatedBy = "Furkan Tolga Kahveci",
                CreatedDate = DateTime.Now,
                IsDeleted = false
              
            });


        
    }
    }
}
