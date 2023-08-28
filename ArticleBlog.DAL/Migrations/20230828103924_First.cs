using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleBlog.DAL.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageID = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Images_Images_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Images",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Articles_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CategoryName", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, "Category 1", "Admin", new DateTime(2023, 8, 28, 13, 39, 23, 971, DateTimeKind.Local).AddTicks(779), null, null, false, null, null },
                    { 2, "Category 2", "Admin", new DateTime(2023, 8, 28, 13, 39, 23, 971, DateTimeKind.Local).AddTicks(783), null, null, false, null, null },
                    { 3, "Category 3", "Admin", new DateTime(2023, 8, 28, 13, 39, 23, 971, DateTimeKind.Local).AddTicks(786), null, null, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "ImageID", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, "Admin", new DateTime(2023, 8, 28, 13, 39, 23, 971, DateTimeKind.Local).AddTicks(2106), null, null, "image1", "jpg", null, false, null, null },
                    { 2, "Admin", new DateTime(2023, 8, 28, 13, 39, 23, 971, DateTimeKind.Local).AddTicks(2111), null, null, "image2", "png", null, false, null, null },
                    { 3, "Admin", new DateTime(2023, 8, 28, 13, 39, 23, 971, DateTimeKind.Local).AddTicks(2113), null, null, "image3", "png", null, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ID", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[] { 1, 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Eren Kartal", new DateTime(2023, 8, 28, 13, 39, 23, 970, DateTimeKind.Local).AddTicks(8504), null, null, 1, false, null, null, "Article", 67 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ID", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[] { 2, 2, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Umut Oncel", new DateTime(2023, 8, 28, 13, 39, 23, 970, DateTimeKind.Local).AddTicks(8511), null, null, 2, false, null, null, "Article", 34 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ID", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[] { 3, 3, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Furkan Kahveci", new DateTime(2023, 8, 28, 13, 39, 23, 970, DateTimeKind.Local).AddTicks(8517), null, null, 3, false, null, null, "Article", 26 });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ImageId",
                table: "Articles",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ImageID",
                table: "Images",
                column: "ImageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
