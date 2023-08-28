using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleBlog.DAL.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Images_ImageID",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ImageID",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ImageID",
                table: "Images");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 21, 32, 32, 684, DateTimeKind.Local).AddTicks(7558));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 21, 32, 32, 684, DateTimeKind.Local).AddTicks(7562));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 21, 32, 32, 684, DateTimeKind.Local).AddTicks(7564));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 21, 32, 32, 684, DateTimeKind.Local).AddTicks(8592));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 21, 32, 32, 684, DateTimeKind.Local).AddTicks(8595));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 21, 32, 32, 684, DateTimeKind.Local).AddTicks(8597));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 21, 32, 32, 684, DateTimeKind.Local).AddTicks(9387));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 21, 32, 32, 684, DateTimeKind.Local).AddTicks(9406));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 21, 32, 32, 684, DateTimeKind.Local).AddTicks(9409));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageID",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 13, 39, 23, 970, DateTimeKind.Local).AddTicks(8504));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 13, 39, 23, 970, DateTimeKind.Local).AddTicks(8511));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 13, 39, 23, 970, DateTimeKind.Local).AddTicks(8517));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 13, 39, 23, 971, DateTimeKind.Local).AddTicks(779));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 13, 39, 23, 971, DateTimeKind.Local).AddTicks(783));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 13, 39, 23, 971, DateTimeKind.Local).AddTicks(786));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 13, 39, 23, 971, DateTimeKind.Local).AddTicks(2106));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 13, 39, 23, 971, DateTimeKind.Local).AddTicks(2111));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 28, 13, 39, 23, 971, DateTimeKind.Local).AddTicks(2113));

            migrationBuilder.CreateIndex(
                name: "IX_Images_ImageID",
                table: "Images",
                column: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Images_ImageID",
                table: "Images",
                column: "ImageID",
                principalTable: "Images",
                principalColumn: "ID");
        }
    }
}
