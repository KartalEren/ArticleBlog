using ArticleBlog.Entitiy.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ArticleBlog.DAL.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .UseIdentityColumn(1, 1);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(x => x.NormalizedUserName)
                   .HasName("UserNameIndex")
                   .IsUnique();

            builder.HasIndex(x => x.NormalizedEmail)
                   .HasName("EmailIndex");

            // Maps to the AspNetUsers table
            builder.ToTable("AspNetUsers"); //tablo adı

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(x => x.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to xse efficient database types
            builder.Property(x => x.UserName)
                   .HasMaxLength(256);

            builder.Property(x => x.NormalizedUserName)
                   .HasMaxLength(256);

            builder.Property(x => x.Email)
                   .HasMaxLength(256);

            builder.Property(x => x.NormalizedEmail)
                   .HasMaxLength(256);




            //burada Identity yapısından gelen PasswordHash probunu kullanabilmemiz için CreatePasswordHash metodunu kullanmamız gerekir ve bunun içinde Seed Data yı builder.HasData olarak değil, bir değişkene atayarak yapacağız.
            //***builder.HasData yı tüm Seed Datayı girince en son değişken adlarını vererek ekleyeceğiz.
            var superAdmin = new AppUser
            {
                Id = 1,
                UserName = "superadmin@gmail.com",
                Email = "superadmin@gmail.com",
                NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                PhoneNumber = "+905536904067",
                FirstName = "Eren",
                LastName = "Kartal",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                ImageId=1
                

            };
            superAdmin.PasswordHash= CreatePasswordHash(superAdmin,"1234");


            //burada Identity yapısından gelen PasswordHash probunu kullanabilmemiz için CreatePasswordHash metodunu kullanmamız gerekir ve bunun içinde Seed Data yı builder.HasData olarak değil, bir değişkene atayarak yapacağız.
            //***builder.HasData yı tüm Seed Datayı girince en son değişken adlarını vererek ekleyeceğiz.
            var admin1 = new AppUser
            {
                Id = 2,
                UserName = "admin1@gmail.com",
                Email = "admin1@gmail.com",
                NormalizedEmail = "ADMIN1@GMAIL.COM",
                PhoneNumber = "+905536904068",
                FirstName = "Umut",
                LastName = "Oncel",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                ImageId = 2

            };
            admin1.PasswordHash = CreatePasswordHash(admin1, "1234");


            //burada Identity yapısından gelen PasswordHash probunu kullanabilmemiz için CreatePasswordHash metodunu kullanmamız gerekir ve bunun içinde Seed Data yı builder.HasData olarak değil, bir değişkene atayarak yapacağız. 
            //***builder.HasData yı tüm Seed Datayı girince en son değişken adlarını vererek ekleyeceğiz.
            var admin2 = new AppUser
            {
                Id = 3,
                UserName = "admin2@gmail.com",
                Email = "admin2@gmail.com",
                NormalizedEmail = "ADMIN2@GMAIL.COM",
                PhoneNumber = "+905536904069",
                FirstName = "Furkan",
                LastName = "Kahveci",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                ImageId = 3

            };
            admin2.PasswordHash = CreatePasswordHash(admin2, "1234");


            builder.HasData(superAdmin, admin1, admin2);


        }


        private string CreatePasswordHash(AppUser user, string password) //Kullanıcı eklediğimizde bunun şifresi Hashlenmiş halde geliyor Identity yapısından dolayı yani farklı hale getiriliyor şifre yapısı değiştiriliyor. Bunun için direkt aynı yazdığımız şifresyi yazıp kullanamıyor kriptolama gibi bir şey yapılıyor. Bunun için direkt yazdığımız şifreyi almasım için bir metot oluşturuyoruz.
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);
        }
    }
}
