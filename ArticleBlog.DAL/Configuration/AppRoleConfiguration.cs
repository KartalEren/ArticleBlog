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
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn(1, 1);


            // Index for "normalized" role name to allow efficient lookups
            builder.HasIndex(x => x.NormalizedName)
                   .HasName("RoleNameIndex")
                   .IsUnique();

            // Maps to the AspNetRoles table
            builder.ToTable("AspNetRoles"); //tablo adı

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(x => x.ConcurrencyStamp)
                   .IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(x => x.Name)
                   .HasMaxLength(256);

            builder.Property(x => x.NormalizedName)
                   .HasMaxLength(256);

            // The relationships between Role and other entity types
            // Note that these relationships are configured with no navigation properties

            builder.HasData(new AppRole
            {
                Id = 1,
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN"
            },
            new AppRole
            {
                Id = 2,
                Name = "Admin",
                NormalizedName = "ADMIN"
            },

            new AppRole
            {
                Id = 3,
                Name = "User",
                NormalizedName = "USER"
            });


        }
    }
}
