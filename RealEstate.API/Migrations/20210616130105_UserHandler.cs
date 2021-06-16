using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.API.Migrations.Repository
{
    public partial class UserHandler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 15, 1, 4, 790, DateTimeKind.Local).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 15, 1, 4, 790, DateTimeKind.Local).AddTicks(1862));

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 15, 1, 4, 787, DateTimeKind.Local).AddTicks(3861));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 15, 1, 4, 790, DateTimeKind.Local).AddTicks(3638));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7e5d5379-9f9e-4bf6-9744-7623008c998d"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 15, 1, 4, 790, DateTimeKind.Local).AddTicks(2915));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 15, 1, 4, 790, DateTimeKind.Local).AddTicks(3650));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 14, 14, 59, 309, DateTimeKind.Local).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 14, 14, 59, 309, DateTimeKind.Local).AddTicks(9430));

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 14, 14, 59, 307, DateTimeKind.Local).AddTicks(6559));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 14, 14, 59, 310, DateTimeKind.Local).AddTicks(972));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7e5d5379-9f9e-4bf6-9744-7623008c998d"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 14, 14, 59, 310, DateTimeKind.Local).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 14, 14, 59, 310, DateTimeKind.Local).AddTicks(985));
        }
    }
}
