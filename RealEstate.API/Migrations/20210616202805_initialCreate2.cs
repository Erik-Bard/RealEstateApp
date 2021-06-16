using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.API.Migrations
{
    public partial class initialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("bb628a76-25b3-451d-9998-d2406ef6e4b7"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 22, 28, 5, 439, DateTimeKind.Local).AddTicks(1341));

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("bb9935ca-5f28-4db1-96a0-4c5a1e3cc692"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 22, 28, 5, 436, DateTimeKind.Local).AddTicks(8167));

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("eff86b15-4872-4c8d-ac32-bf351fb71a2c"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 22, 28, 5, 439, DateTimeKind.Local).AddTicks(1518));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("acbcb3d5-64e2-420b-93c7-99d3435377f9"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 22, 28, 5, 439, DateTimeKind.Local).AddTicks(3785));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("b2aa2881-9021-4d91-88ff-8f452dccc105"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 22, 28, 5, 439, DateTimeKind.Local).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c30141ec-acfa-4a5f-8869-c1fedcc410be"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 22, 28, 5, 439, DateTimeKind.Local).AddTicks(2653));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("bb628a76-25b3-451d-9998-d2406ef6e4b7"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 21, 49, 5, 736, DateTimeKind.Local).AddTicks(4682));

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("bb9935ca-5f28-4db1-96a0-4c5a1e3cc692"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 21, 49, 5, 734, DateTimeKind.Local).AddTicks(865));

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("eff86b15-4872-4c8d-ac32-bf351fb71a2c"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 21, 49, 5, 736, DateTimeKind.Local).AddTicks(4715));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("acbcb3d5-64e2-420b-93c7-99d3435377f9"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 21, 49, 5, 736, DateTimeKind.Local).AddTicks(6953));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("b2aa2881-9021-4d91-88ff-8f452dccc105"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 21, 49, 5, 736, DateTimeKind.Local).AddTicks(6940));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c30141ec-acfa-4a5f-8869-c1fedcc410be"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 21, 49, 5, 736, DateTimeKind.Local).AddTicks(5835));
        }
    }
}
