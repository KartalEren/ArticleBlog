using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleBlog.DAL.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Umut Oncel", new DateTime(2023, 8, 26, 18, 24, 39, 664, DateTimeKind.Local).AddTicks(148) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Furkan Tolga Kahveci", new DateTime(2023, 8, 26, 18, 24, 39, 664, DateTimeKind.Local).AddTicks(158) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 26, 18, 24, 39, 664, DateTimeKind.Local).AddTicks(1462));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 26, 18, 24, 39, 664, DateTimeKind.Local).AddTicks(1467));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 26, 18, 24, 39, 664, DateTimeKind.Local).AddTicks(2425));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 26, 18, 24, 39, 664, DateTimeKind.Local).AddTicks(2430));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2023, 8, 26, 3, 34, 56, 461, DateTimeKind.Local).AddTicks(6195) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2023, 8, 26, 3, 34, 56, 461, DateTimeKind.Local).AddTicks(6199) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 26, 3, 34, 56, 461, DateTimeKind.Local).AddTicks(7170));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 26, 3, 34, 56, 461, DateTimeKind.Local).AddTicks(7173));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 26, 3, 34, 56, 461, DateTimeKind.Local).AddTicks(7656));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 26, 3, 34, 56, 461, DateTimeKind.Local).AddTicks(7659));
        }
    }
}
