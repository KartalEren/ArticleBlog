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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .UseIdentityColumn(1, 1);

            builder.Property(x => x.CategoryName)
                .HasMaxLength(75);


            builder.HasData(new Category
            {
                ID = 1,
                CategoryName = "Category 1",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Category
            {
                ID = 2,
                CategoryName = "Category 2",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                IsDeleted = false

            });

        }
    }
    
}
