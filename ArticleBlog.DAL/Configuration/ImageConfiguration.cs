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
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityColumn(1, 1);

            builder.Property(x => x.FileName)
                .HasMaxLength(75);

            builder.HasData(new Image
            {
                ID = 1,
                FileName = "image1",
                FileType = "jpg",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
           new Image
           {
               ID = 2,
               FileName = "image2",
               FileType = "png",
               CreatedBy = "Admin",
               CreatedDate = DateTime.Now,
               IsDeleted = false
           },
            new Image
            {
                ID = 3,
                FileName = "image3",
                FileType = "png",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });


        }
    }
}
