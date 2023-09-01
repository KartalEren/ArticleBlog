using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleBlog.DAL.IdentityMigrations
{
    public partial class Sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 17, 32, 28, 264, DateTimeKind.Local).AddTicks(2257));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 17, 32, 28, 264, DateTimeKind.Local).AddTicks(2261));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 17, 32, 28, 264, DateTimeKind.Local).AddTicks(2264));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0f5e67d1-63c1-463f-bcb5-63d345e03c9d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "4fb3dd6e-95c9-4f77-a355-e20ae7982ebf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "9730b834-8ee4-40c1-a246-fd7241ffea29");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5bbdd8a9-8560-4c38-9ffc-6e1a5f9d3406", "AQAAAAEAACcQAAAAEP/upxhoDaTcm/gXy2I543mLVun6OwNEzVDYwDb70XuD7A4buUePtSbRe9+/9tveZQ==", "2619de24-619a-433e-aebb-384e5eea3d76" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17db58b1-dc0c-45c6-add3-69459813edd7", "AQAAAAEAACcQAAAAEBYxlJb1dMDsYUKiTWws8qymkfOVNZSsmJ4J8+6xUwHivJ6MJS3U+hdezplBs6fduw==", "266eeb88-a3d9-4e99-9d14-bae86e1b0a53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d29e29a8-5ead-4f79-846e-966e034731c1", "AQAAAAEAACcQAAAAEDFhuP/WJmqSqcdX+9t515QSkNIOa+cAjW0YDw7ksBje9dCeIDjoNcoB6Bg0v+KF6g==", "a9156801-8f78-491f-bbc1-0d6fcc49b46f" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 17, 32, 28, 264, DateTimeKind.Local).AddTicks(5766));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 17, 32, 28, 264, DateTimeKind.Local).AddTicks(5769));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 17, 32, 28, 264, DateTimeKind.Local).AddTicks(5771));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 17, 32, 28, 264, DateTimeKind.Local).AddTicks(6824));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 17, 32, 28, 264, DateTimeKind.Local).AddTicks(6827));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 17, 32, 28, 264, DateTimeKind.Local).AddTicks(6830));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Article",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 12, 54, 25, 164, DateTimeKind.Local).AddTicks(5076));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 12, 54, 25, 164, DateTimeKind.Local).AddTicks(5082));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 12, 54, 25, 164, DateTimeKind.Local).AddTicks(5085));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0f98eb12-d0e6-4e04-80fe-6a395c59c471");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "5dadb886-a73b-4d92-95c1-c2aa80fcfd96");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "a9cb4edd-a663-417f-a688-4439b390ae00");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "541f7c18-c88c-4b61-a9ae-92126748d0f0", "AQAAAAEAACcQAAAAEB2hvmdGeshmGG8SCSNllLC/ZzZWvwyLI1a+MzazlUCsOIKN4GqvWLRh7foAyRT+8A==", "b7303951-4a6c-4f91-8baf-b424fe6686b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70c349fd-540d-4282-a053-c7f23de20e7a", "AQAAAAEAACcQAAAAEMDdTvMZsCYd0izc/ABY00zt44xctr7bx8neu5ROgIPBlSrgrbIDACQ3KlxABH4+jg==", "4e077210-bd87-4ed3-833c-e96f85b1b5f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d519526c-8ecc-4e9f-909b-428e14911151", "AQAAAAEAACcQAAAAEITqY+qHxYAwDtBQlbvAvzIiSOe/DB3+sMZuzhABW8iqG2H96zotAIbLmtOlj1hEpg==", "be843ac2-2ddf-4208-9dc8-55e2593e6a73" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 12, 54, 25, 165, DateTimeKind.Local).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 12, 54, 25, 165, DateTimeKind.Local).AddTicks(1754));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 12, 54, 25, 165, DateTimeKind.Local).AddTicks(1759));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 12, 54, 25, 165, DateTimeKind.Local).AddTicks(4541));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 12, 54, 25, 165, DateTimeKind.Local).AddTicks(4546));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 12, 54, 25, 165, DateTimeKind.Local).AddTicks(4549));
        }
    }
}
