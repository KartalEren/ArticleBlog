using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleBlog.DAL.IdentityMigrations
{
    public partial class seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConfirmCode",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmCode",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 17, 32, 28, 264, DateTimeKind.Local).AddTicks(2257));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 17, 32, 28, 264, DateTimeKind.Local).AddTicks(2261));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 17, 32, 28, 264, DateTimeKind.Local).AddTicks(2264));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0f5e67d1-63c1-463f-bcb5-63d345e03c9d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "4fb3dd6e-95c9-4f77-a355-e20ae7982ebf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "9730b834-8ee4-40c1-a246-fd7241ffea29");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5bbdd8a9-8560-4c38-9ffc-6e1a5f9d3406", "AQAAAAEAACcQAAAAEP/upxhoDaTcm/gXy2I543mLVun6OwNEzVDYwDb70XuD7A4buUePtSbRe9+/9tveZQ==", "2619de24-619a-433e-aebb-384e5eea3d76" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17db58b1-dc0c-45c6-add3-69459813edd7", "AQAAAAEAACcQAAAAEBYxlJb1dMDsYUKiTWws8qymkfOVNZSsmJ4J8+6xUwHivJ6MJS3U+hdezplBs6fduw==", "266eeb88-a3d9-4e99-9d14-bae86e1b0a53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d29e29a8-5ead-4f79-846e-966e034731c1", "AQAAAAEAACcQAAAAEDFhuP/WJmqSqcdX+9t515QSkNIOa+cAjW0YDw7ksBje9dCeIDjoNcoB6Bg0v+KF6g==", "a9156801-8f78-491f-bbc1-0d6fcc49b46f" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 17, 32, 28, 264, DateTimeKind.Local).AddTicks(5766));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 17, 32, 28, 264, DateTimeKind.Local).AddTicks(5769));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 17, 32, 28, 264, DateTimeKind.Local).AddTicks(5771));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 17, 32, 28, 264, DateTimeKind.Local).AddTicks(6824));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 17, 32, 28, 264, DateTimeKind.Local).AddTicks(6827));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 17, 32, 28, 264, DateTimeKind.Local).AddTicks(6830));
        }
    }
}
