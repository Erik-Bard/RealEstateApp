using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.API.Migrations.Repository
{
    public partial class TokenHandler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 11, 38, 7, 269, DateTimeKind.Local).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 11, 38, 7, 269, DateTimeKind.Local).AddTicks(5009));

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 11, 38, 7, 267, DateTimeKind.Local).AddTicks(1910));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 11, 38, 7, 269, DateTimeKind.Local).AddTicks(6520));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7e5d5379-9f9e-4bf6-9744-7623008c998d"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 11, 38, 7, 269, DateTimeKind.Local).AddTicks(5837));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 11, 38, 7, 269, DateTimeKind.Local).AddTicks(6534));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 9, 13, 59, 289, DateTimeKind.Local).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 9, 13, 59, 289, DateTimeKind.Local).AddTicks(5804));

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 9, 13, 59, 287, DateTimeKind.Local).AddTicks(1886));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 9, 13, 59, 289, DateTimeKind.Local).AddTicks(7458));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7e5d5379-9f9e-4bf6-9744-7623008c998d"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 9, 13, 59, 289, DateTimeKind.Local).AddTicks(6777));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 16, 9, 13, 59, 289, DateTimeKind.Local).AddTicks(7471));
        }
    }
}
