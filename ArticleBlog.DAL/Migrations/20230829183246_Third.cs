using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleBlog.DAL.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 44, 28, 479, DateTimeKind.Local).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 44, 28, 479, DateTimeKind.Local).AddTicks(4287));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 44, 28, 479, DateTimeKind.Local).AddTicks(4293));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 44, 28, 479, DateTimeKind.Local).AddTicks(7524));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 44, 28, 479, DateTimeKind.Local).AddTicks(7530));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 44, 28, 479, DateTimeKind.Local).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 44, 28, 479, DateTimeKind.Local).AddTicks(8588));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 44, 28, 479, DateTimeKind.Local).AddTicks(8594));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 20, 44, 28, 479, DateTimeKind.Local).AddTicks(8597));
        }
    }
}
