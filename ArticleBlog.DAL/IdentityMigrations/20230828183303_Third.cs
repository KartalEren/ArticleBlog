using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleBlog.DAL.IdentityMigrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Image_ImageID",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_ImageID",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "ImageID",
                table: "Image");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 21, 33, 3, 18, DateTimeKind.Local).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 21, 33, 3, 18, DateTimeKind.Local).AddTicks(7514));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 21, 33, 3, 18, DateTimeKind.Local).AddTicks(7517));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "bfaa5319-70a6-4f60-80b2-daa454e5d213");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "c7fe7a52-2aa8-4455-8d1f-30c9e37afe6d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "24f10a33-28bd-48ae-ac36-58b34c86d914");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdd0fe4f-75cd-40fa-884c-3b46984ccdb1", "AQAAAAEAACcQAAAAEGfyvV9xVNCokiJBsTd8GfVszzA2g/0k8GWN7ix04mi7G8SWDIBcmiDRUETertuYXw==", "023d5a0a-8d98-4a56-8a10-03e73f704ac6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c15d2fce-7327-4f2f-94cb-ebbce5171cf6", "AQAAAAEAACcQAAAAEPQC7pzioporQ61zNLzY+EjYg1QQ4VXulerU53dCsvYm67i58W1akUX01NQp+L633Q==", "b703623a-9408-4459-8a92-4d38a9acfcd2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d41e09b5-8477-43c9-8582-89213afb58f9", "AQAAAAEAACcQAAAAEHUh14eBLX/2ylgRRGDYV1LA5NCujeA0HyvI8lsHnVxL8eDPHJqCOSdBa7fA1IY+BA==", "f534743a-9464-4832-9e8a-9d7116e1ecab" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 21, 33, 3, 19, DateTimeKind.Local).AddTicks(1021));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 21, 33, 3, 19, DateTimeKind.Local).AddTicks(1026));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 21, 33, 3, 19, DateTimeKind.Local).AddTicks(1033));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 21, 33, 3, 19, DateTimeKind.Local).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 21, 33, 3, 19, DateTimeKind.Local).AddTicks(3746));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 21, 33, 3, 19, DateTimeKind.Local).AddTicks(3751));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageID",
                table: "Image",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 18, 45, 35, 247, DateTimeKind.Local).AddTicks(2791));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 18, 45, 35, 247, DateTimeKind.Local).AddTicks(2794));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 18, 45, 35, 247, DateTimeKind.Local).AddTicks(2797));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e64ca90b-f58f-4b05-8c5e-7a31e531761d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b1c04f33-1bb8-4a4c-a76d-bbaf77127251");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "e2949c09-0342-40bf-b973-b7bf4ffd5495");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f719aac9-203d-4eed-8519-c9f6200bcb6c", "AQAAAAEAACcQAAAAEOw9yoiCUI7qVqyHp9gOUxJIGHjeyq7Z8AnsxyDgNJHi3wqJDqnsEOIteuoVKqTkog==", "0f73bd50-9d9d-44e5-ac6f-4c35d74bf6c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ccc8ba2-6c9c-4ead-b8ae-e92cfe1d73ef", "AQAAAAEAACcQAAAAEERFlf3i8Hy6IrldIX65UbgfNGpBLv2yvDMsbKmkAt0T6iPQCObe33wi3YRofhXn6w==", "53e8c2d1-5f5d-4212-acb3-c976cd9f4d16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "547eab07-1911-4fb2-a18d-bbcda60e4f05", "AQAAAAEAACcQAAAAEJ6E489/Lf1XoY7UabRJwri91o9z5qWjV2bjKuKjqgG382mNpzz3b7Moo8pkGuGVfQ==", "ce7c1c79-d3b8-49c0-9327-28457255250c" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 18, 45, 35, 247, DateTimeKind.Local).AddTicks(3664));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 18, 45, 35, 247, DateTimeKind.Local).AddTicks(3667));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 18, 45, 35, 247, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 18, 45, 35, 247, DateTimeKind.Local).AddTicks(4491));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 18, 45, 35, 247, DateTimeKind.Local).AddTicks(4494));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 18, 45, 35, 247, DateTimeKind.Local).AddTicks(4496));

            migrationBuilder.CreateIndex(
                name: "IX_Image_ImageID",
                table: "Image",
                column: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Image_ImageID",
                table: "Image",
                column: "ImageID",
                principalTable: "Image",
                principalColumn: "ID");
        }
    }
}
