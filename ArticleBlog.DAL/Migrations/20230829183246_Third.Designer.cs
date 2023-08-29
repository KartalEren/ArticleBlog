﻿// <auto-generated />
using System;
using ArticleBlog.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArticleBlog.DAL.Migrations
{
    [DbContext(typeof(BlogDBContext))]
    [Migration("20230829183246_Third")]
    partial class Third
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ArticleBlog.Entitiy.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("ArticleBlog.Entitiy.Entities.Article", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CategoryId = 1,
                            Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            CreatedBy = "Eren Kartal",
                            CreatedDate = new DateTime(2023, 8, 29, 21, 32, 46, 91, DateTimeKind.Local).AddTicks(9057),
                            ImageId = 1,
                            IsDeleted = false,
                            Title = "Article",
                            UserId = 1,
                            ViewCount = 67
                        },
                        new
                        {
                            ID = 2,
                            CategoryId = 2,
                            Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            CreatedBy = "Umut Oncel",
                            CreatedDate = new DateTime(2023, 8, 29, 21, 32, 46, 91, DateTimeKind.Local).AddTicks(9062),
                            ImageId = 2,
                            IsDeleted = false,
                            Title = "Article",
                            UserId = 2,
                            ViewCount = 34
                        },
                        new
                        {
                            ID = 3,
                            CategoryId = 3,
                            Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            CreatedBy = "Furkan Kahveci",
                            CreatedDate = new DateTime(2023, 8, 29, 21, 32, 46, 91, DateTimeKind.Local).AddTicks(9066),
                            ImageId = 3,
                            IsDeleted = false,
                            Title = "Article",
                            UserId = 3,
                            ViewCount = 26
                        });
                });

            modelBuilder.Entity("ArticleBlog.Entitiy.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CategoryName = "Category 1",
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 8, 29, 21, 32, 46, 92, DateTimeKind.Local).AddTicks(702),
                            IsDeleted = false
                        },
                        new
                        {
                            ID = 2,
                            CategoryName = "Category 2",
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 8, 29, 21, 32, 46, 92, DateTimeKind.Local).AddTicks(704),
                            IsDeleted = false
                        },
                        new
                        {
                            ID = 3,
                            CategoryName = "Category 3",
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 8, 29, 21, 32, 46, 92, DateTimeKind.Local).AddTicks(706),
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("ArticleBlog.Entitiy.Entities.Image", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 8, 29, 21, 32, 46, 92, DateTimeKind.Local).AddTicks(1404),
                            FileName = "image1",
                            FileType = "jpg",
                            IsDeleted = false
                        },
                        new
                        {
                            ID = 2,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 8, 29, 21, 32, 46, 92, DateTimeKind.Local).AddTicks(1407),
                            FileName = "image2",
                            FileType = "png",
                            IsDeleted = false
                        },
                        new
                        {
                            ID = 3,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 8, 29, 21, 32, 46, 92, DateTimeKind.Local).AddTicks(1410),
                            FileName = "image3",
                            FileType = "png",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("ArticleBlog.Entitiy.Entities.AppUser", b =>
                {
                    b.HasOne("ArticleBlog.Entitiy.Entities.Image", null)
                        .WithMany("Users")
                        .HasForeignKey("ImageId");
                });

            modelBuilder.Entity("ArticleBlog.Entitiy.Entities.Article", b =>
                {
                    b.HasOne("ArticleBlog.Entitiy.Entities.AppUser", null)
                        .WithMany("Articles")
                        .HasForeignKey("AppUserId");

                    b.HasOne("ArticleBlog.Entitiy.Entities.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ArticleBlog.Entitiy.Entities.Image", "Image")
                        .WithMany("Articles")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Category");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("ArticleBlog.Entitiy.Entities.AppUser", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("ArticleBlog.Entitiy.Entities.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("ArticleBlog.Entitiy.Entities.Image", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
