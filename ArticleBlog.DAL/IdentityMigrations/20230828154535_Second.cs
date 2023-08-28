using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleBlog.DAL.IdentityMigrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f719aac9-203d-4eed-8519-c9f6200bcb6c", "SUPERADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEOw9yoiCUI7qVqyHp9gOUxJIGHjeyq7Z8AnsxyDgNJHi3wqJDqnsEOIteuoVKqTkog==", "0f73bd50-9d9d-44e5-ac6f-4c35d74bf6c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ccc8ba2-6c9c-4ead-b8ae-e92cfe1d73ef", "ADMIN1@GMAIL.COM", "AQAAAAEAACcQAAAAEERFlf3i8Hy6IrldIX65UbgfNGpBLv2yvDMsbKmkAt0T6iPQCObe33wi3YRofhXn6w==", "53e8c2d1-5f5d-4212-acb3-c976cd9f4d16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "547eab07-1911-4fb2-a18d-bbcda60e4f05", "ADMIN2@GMAIL.COM", "AQAAAAEAACcQAAAAEJ6E489/Lf1XoY7UabRJwri91o9z5qWjV2bjKuKjqgG382mNpzz3b7Moo8pkGuGVfQ==", "ce7c1c79-d3b8-49c0-9327-28457255250c" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 13, 40, 55, 351, DateTimeKind.Local).AddTicks(839));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 13, 40, 55, 351, DateTimeKind.Local).AddTicks(844));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 13, 40, 55, 351, DateTimeKind.Local).AddTicks(847));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "202d1a93-b15c-4b34-a160-7d98af81e56e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "c3871151-dd8d-4fc3-b8a9-7bb9a4ef6826");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "0623f55f-8e0a-4934-b515-82b8862db614");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94ae0287-3d5b-41c4-b2b1-1a3cb27d47b4", null, "AQAAAAEAACcQAAAAEKZURyWzZ2DF0fdoxNoaPguLhJPTLsXnFhGz1ZLqONFnISnjt3+II7WpTMtD0EcmhA==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f38b2af-42d4-4ab8-ba1e-084d1835d631", null, "AQAAAAEAACcQAAAAEOcZwj89aa4F1DuFeRlZrpWj4hZG/IqPM5DFvBzV4a5/5bfcIVAIo80Ca/3U/Zw2jw==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3fd6b37-6830-41fc-abdf-1658d891c547", null, "AQAAAAEAACcQAAAAECaVu8Jr4rb8uA3Ksat8WcZLNcnvOnMD8CgYHvjRee6w+0T7bCA9GOP31xPXhxQ8Xw==", null });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 13, 40, 55, 351, DateTimeKind.Local).AddTicks(1942));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 13, 40, 55, 351, DateTimeKind.Local).AddTicks(2081));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 13, 40, 55, 351, DateTimeKind.Local).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 13, 40, 55, 351, DateTimeKind.Local).AddTicks(2907));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 13, 40, 55, 351, DateTimeKind.Local).AddTicks(2910));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 13, 40, 55, 351, DateTimeKind.Local).AddTicks(2913));
        }
    }
}
