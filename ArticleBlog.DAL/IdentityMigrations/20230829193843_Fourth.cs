using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleBlog.DAL.IdentityMigrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 22, 38, 42, 869, DateTimeKind.Local).AddTicks(8816));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 22, 38, 42, 869, DateTimeKind.Local).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 22, 38, 42, 869, DateTimeKind.Local).AddTicks(8822));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "5510fb60-5d46-4cb1-82e7-4cb55375178e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "ee1649c1-221a-4e24-86d1-e6388cd616eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "14858018-8956-44c1-8f3f-84b6b0671a34");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c8d48dc-d036-48e3-9ddc-16b119423650", "AQAAAAEAACcQAAAAEMjPXIq9T1/tOc9ZkRxImU6BmVewOu2ced0L0wTuFNUqVQ5yEQmEgqkV9OiknUhKLg==", "8dec4083-ce6e-446b-9886-7a60686783c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53a5679d-a312-4fe1-a4f5-4cd59a9d60f4", "AQAAAAEAACcQAAAAEPCH4QEsoclbupEB/1V+HVvOutI941F3sqaL5KFfdoIjfApnA9WLHnlBF2bVT8rQAA==", "18a01889-0c7a-410f-83b3-510162a1e533" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84af97af-aafb-4188-98be-37c966edf83a", "AQAAAAEAACcQAAAAEMEVB8NWRi9vUoKgA5BmpsxaXD1MWxtuK7ghSUcr6ZgDz41P8wPQx13FYShHsPLS8Q==", "5a6a6648-784c-4a55-af14-5cf7ba2e0739" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 22, 38, 42, 869, DateTimeKind.Local).AddTicks(9811));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 22, 38, 42, 869, DateTimeKind.Local).AddTicks(9974));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 22, 38, 42, 869, DateTimeKind.Local).AddTicks(9977));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 22, 38, 42, 870, DateTimeKind.Local).AddTicks(828));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 22, 38, 42, 870, DateTimeKind.Local).AddTicks(831));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 29, 22, 38, 42, 870, DateTimeKind.Local).AddTicks(984));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
