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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Image_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Image_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 11, 30, 10, 195, DateTimeKind.Local).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 11, 30, 10, 195, DateTimeKind.Local).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 11, 30, 10, 195, DateTimeKind.Local).AddTicks(4852));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "de77fa5d-4bf1-4540-afef-213383a70daf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f34a937d-beb0-4b5d-bbeb-3cb649356e9a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "0413a9b5-f69e-4902-a588-b7b0d6ba36fd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c034e993-acd0-4555-bb59-a40845e526da", "AQAAAAEAACcQAAAAEPDOzmNfYao90e+zG5bO1NKUAPHinU/Q60HhLpxJX/sl0WUfpq1CoifYSyLl0l7NGQ==", "bdf2b0b2-6fc9-4e0e-abe5-2fbd3bc04567" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f3afb7e-8597-44f2-bde0-7abc644076c1", "AQAAAAEAACcQAAAAECFMB0t14LcyPehB26PglfwX+5N5uUIMqzzhqoNI6px7JrocctSRbuYjp+6PgEcFyA==", "8658dd2b-e8ff-4f5a-9499-5f21fb4b39a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3103997e-21b3-4854-ad86-85ca2e1c5216", "AQAAAAEAACcQAAAAEBje48/Gk/mz70JkLEDdew2EitnSvG/DRCwqyiArRb8oxI2VMAlHhaV5BBxB3j7qNw==", "e32054e9-3e98-445f-afcd-c217f9ebc26f" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 11, 30, 10, 195, DateTimeKind.Local).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 11, 30, 10, 195, DateTimeKind.Local).AddTicks(6335));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 11, 30, 10, 195, DateTimeKind.Local).AddTicks(6338));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 11, 30, 10, 195, DateTimeKind.Local).AddTicks(8239));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 11, 30, 10, 195, DateTimeKind.Local).AddTicks(8245));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 11, 30, 10, 195, DateTimeKind.Local).AddTicks(8248));
        }
    }
}
