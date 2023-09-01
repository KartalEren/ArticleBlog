using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleBlog.DAL.IdentityMigrations
{
    public partial class nineth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Article",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 18, 34, 13, 484, DateTimeKind.Local).AddTicks(2381));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 18, 34, 13, 484, DateTimeKind.Local).AddTicks(2385));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 18, 34, 13, 484, DateTimeKind.Local).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a6a196d5-ed56-4e8b-94f1-4aa153a90a3f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "ac228e8a-6df5-4c7c-ac4b-edef80aaa046");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "d06b2fe2-7b01-4ec2-af94-54d274410f74");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ba65f26-cc7f-4bfa-82d3-bff68a1549db", "AQAAAAEAACcQAAAAEL9eXY+if4WKTZMHwSeSE8JbdiSXYOp1P+0Snc+lzngWv6MSovbPW7AhNfBC1RokVg==", "d34e62d7-2c99-4d65-9737-afef934dee5c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f35b460f-a53b-4fc3-8bfc-0cf6c6d7c054", "AQAAAAEAACcQAAAAEIB63qzyszCviouEgiiqwTtst1N3THjVo6EldKfiQHVZlSw3ry4Rd9DrBrSTEguUNA==", "506a1bd2-b731-4571-9067-1f326194ddbd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60e59715-cea5-45cd-9d21-19c518dbedde", "AQAAAAEAACcQAAAAEAnPvmz7ygxb45apv7q+2PwUosjRta8Y5jte8LZRUI4J8V597XP2raKz5ci13sq5iw==", "62cabbff-48d6-4d79-b465-ee6def57331a" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 18, 34, 13, 484, DateTimeKind.Local).AddTicks(6641));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 18, 34, 13, 484, DateTimeKind.Local).AddTicks(6644));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 18, 34, 13, 484, DateTimeKind.Local).AddTicks(6646));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 18, 34, 13, 484, DateTimeKind.Local).AddTicks(7656));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 18, 34, 13, 484, DateTimeKind.Local).AddTicks(7659));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 18, 34, 13, 484, DateTimeKind.Local).AddTicks(7661));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 18, 6, 31, 539, DateTimeKind.Local).AddTicks(4233));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 18, 6, 31, 539, DateTimeKind.Local).AddTicks(4237));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 18, 6, 31, 539, DateTimeKind.Local).AddTicks(4240));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7f7b5ce9-d949-4ea4-8285-bd858d37f96b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "44e23981-a76b-4d0f-a827-7811ffb32b43");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "7c962828-7635-46b7-b0d4-166ed04a8ab7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52663641-b832-4a1b-bcfe-325a68a76768", "AQAAAAEAACcQAAAAEP9ARKnsOWFzYR+06J/bisulaqi15FYB0cLXiSxg+j4dPQKYW+JCcA+RY3Q8b4Ke7A==", "92185a8f-a168-40b6-a07e-69894ca6320b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "668d0aee-d302-4a15-b959-e07db5398cc3", "AQAAAAEAACcQAAAAEAAhwzwvjgQIbVxCyLUHaqNVU9uMU5rrcvGcv74AjVkkGr/lwoK7b1M4aQ8cDWM05Q==", "f2399861-fbcd-49ac-8b02-cf7f1df50ea4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f0ef329-4493-4e77-953b-76eeb080164d", "AQAAAAEAACcQAAAAEOULdY8eY9yDadbWi9oYAmnHlUBI27L1k85VZrW4ufQJvAnCcA69OK9xJppTJ1dsxA==", "8ce9f425-4017-4395-a14a-1c5f6a9da96c" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 18, 6, 31, 539, DateTimeKind.Local).AddTicks(7763));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 18, 6, 31, 539, DateTimeKind.Local).AddTicks(7765));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 18, 6, 31, 539, DateTimeKind.Local).AddTicks(7767));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 18, 6, 31, 539, DateTimeKind.Local).AddTicks(8698));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 18, 6, 31, 539, DateTimeKind.Local).AddTicks(8702));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 18, 6, 31, 539, DateTimeKind.Local).AddTicks(8705));
        }
    }
}
