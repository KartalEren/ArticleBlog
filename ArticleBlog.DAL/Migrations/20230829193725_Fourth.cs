using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleBlog.DAL.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 22, 37, 24, 625, DateTimeKind.Local).AddTicks(4029));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 22, 37, 24, 625, DateTimeKind.Local).AddTicks(4032));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 22, 37, 24, 625, DateTimeKind.Local).AddTicks(4035));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 22, 37, 24, 625, DateTimeKind.Local).AddTicks(4857));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 22, 37, 24, 625, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 22, 37, 24, 625, DateTimeKind.Local).AddTicks(4862));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 22, 37, 24, 625, DateTimeKind.Local).AddTicks(5359));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 22, 37, 24, 625, DateTimeKind.Local).AddTicks(5363));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 22, 37, 24, 625, DateTimeKind.Local).AddTicks(5372));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 21, 32, 46, 91, DateTimeKind.Local).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 21, 32, 46, 91, DateTimeKind.Local).AddTicks(9062));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 21, 32, 46, 91, DateTimeKind.Local).AddTicks(9066));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 21, 32, 46, 92, DateTimeKind.Local).AddTicks(702));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 21, 32, 46, 92, DateTimeKind.Local).AddTicks(704));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 21, 32, 46, 92, DateTimeKind.Local).AddTicks(706));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 21, 32, 46, 92, DateTimeKind.Local).AddTicks(1404));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 21, 32, 46, 92, DateTimeKind.Local).AddTicks(1407));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 21, 32, 46, 92, DateTimeKind.Local).AddTicks(1410));
        }
    }
}
