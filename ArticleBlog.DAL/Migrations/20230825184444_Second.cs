using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleBlog.DAL.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Content", "CreatedDate" },
                values: new object[] { "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTime(2023, 8, 25, 21, 44, 43, 146, DateTimeKind.Local).AddTicks(8556) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Content", "CreatedDate" },
                values: new object[] { "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTime(2023, 8, 25, 21, 44, 43, 146, DateTimeKind.Local).AddTicks(8561) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 21, 44, 43, 147, DateTimeKind.Local).AddTicks(994));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 21, 44, 43, 147, DateTimeKind.Local).AddTicks(998));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 21, 44, 43, 147, DateTimeKind.Local).AddTicks(2035));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 21, 44, 43, 147, DateTimeKind.Local).AddTicks(2039));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Content", "CreatedDate" },
                values: new object[] { "ArticleArticleArticleArticleArticleArticle", new DateTime(2023, 8, 25, 21, 27, 11, 938, DateTimeKind.Local).AddTicks(5799) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Content", "CreatedDate" },
                values: new object[] { "ArticleArticleArticleArticleArticleArticle", new DateTime(2023, 8, 25, 21, 27, 11, 938, DateTimeKind.Local).AddTicks(5802) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 21, 27, 11, 938, DateTimeKind.Local).AddTicks(7020));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 21, 27, 11, 938, DateTimeKind.Local).AddTicks(7024));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 21, 27, 11, 938, DateTimeKind.Local).AddTicks(7797));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 21, 27, 11, 938, DateTimeKind.Local).AddTicks(7801));
        }
    }
}
