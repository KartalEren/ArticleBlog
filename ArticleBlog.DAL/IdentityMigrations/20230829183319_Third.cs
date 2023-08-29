using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleBlog.DAL.IdentityMigrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 21, 33, 18, 606, DateTimeKind.Local).AddTicks(3222));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 21, 33, 18, 606, DateTimeKind.Local).AddTicks(3227));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 21, 33, 18, 606, DateTimeKind.Local).AddTicks(3230));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "21e6dcd1-9705-4126-b2fe-da4c49ac1988");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "331c2d77-2fb7-411c-a6c0-e3d99224a0c6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "83e233cc-d186-460e-a0a7-b57d5fd4d490");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7660889a-5ea2-437e-8de7-8e9bba0a3194", "AQAAAAEAACcQAAAAECm2mxAqFZg/Beguck+kdmr1xcJDE/MUDrXcoyiu9izbT/ZTV1Tv76iDfxWv5t0+UQ==", "7b7b9933-7935-4a21-a201-397b8b3c9363" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2308e118-f2e6-4479-8d52-f7f2e603bc92", "AQAAAAEAACcQAAAAEDMrw60IARJGTx5IGK8Lz0VMdRwaqllzn4OLis6BuE/HgcaP263GGsEBGTzuRu/FMA==", "5b03e390-ea84-49a1-8758-5211c5517f8e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d7eba61-989d-4210-8ed1-bf2bf2427d27", "AQAAAAEAACcQAAAAELgmw4WnApgcgxT1kHC52ZM/YTeIpBpso4LJXcp4SufxncYD95ClcUic9/Nb28uZmw==", "8ec37f5e-28fa-4961-8e71-5806c1dd1461" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 21, 33, 18, 606, DateTimeKind.Local).AddTicks(6110));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 21, 33, 18, 606, DateTimeKind.Local).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 21, 33, 18, 606, DateTimeKind.Local).AddTicks(6119));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 21, 33, 18, 606, DateTimeKind.Local).AddTicks(7844));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 21, 33, 18, 606, DateTimeKind.Local).AddTicks(7849));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 21, 33, 18, 606, DateTimeKind.Local).AddTicks(7852));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 46, 0, 676, DateTimeKind.Local).AddTicks(8784));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 46, 0, 676, DateTimeKind.Local).AddTicks(8788));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 46, 0, 676, DateTimeKind.Local).AddTicks(8791));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "2c3d9ead-ca52-4e63-9aa5-d3d8b350522c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "aef09840-69d9-42ab-9b21-51ebb11f9a9f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "f84b87e6-1451-4cd1-9664-7a4d88a57586");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "465a23b2-b002-4931-835e-61377dd0f7d2", "AQAAAAEAACcQAAAAELMn1RNvyQ3WBqsyvHAK1nzv6hgd9YVS2wfpMqpLKssHoPLI3fRsmBc1SmA3Xa00fg==", "c977e152-7cd0-4637-8b85-03a86ebadc10" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9c2586e-73de-4c3e-998e-733ed19c0c7d", "AQAAAAEAACcQAAAAEHHvHODmlm2y3UPveBgGdczTnz0puTbHCRXxvqL1JBJQMWQAenCZxxUdO+a8SyP4wA==", "762bf5a5-24b8-4503-9767-be2dd8938373" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "acd0375d-872f-4ca8-92d2-be29c4ad2f9c", "AQAAAAEAACcQAAAAEMtrSywUOWSjMM13S1Qy0mjtFFbfi95tOJumcFAvznKNf9KHnaiSvateMkGp3ZW/nQ==", "01c83719-d265-4c45-a481-295aabe5e2dc" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 46, 0, 676, DateTimeKind.Local).AddTicks(9913));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 46, 0, 676, DateTimeKind.Local).AddTicks(9915));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 46, 0, 676, DateTimeKind.Local).AddTicks(9918));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 46, 0, 677, DateTimeKind.Local).AddTicks(698));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 46, 0, 677, DateTimeKind.Local).AddTicks(701));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 46, 0, 677, DateTimeKind.Local).AddTicks(703));
        }
    }
}
