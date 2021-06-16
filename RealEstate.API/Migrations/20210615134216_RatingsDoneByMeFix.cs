using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.API.Migrations.Repository
{
    public partial class RatingsDoneByMeFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 15, 42, 16, 307, DateTimeKind.Local).AddTicks(3987));

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 15, 42, 16, 307, DateTimeKind.Local).AddTicks(4021));

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 15, 42, 16, 304, DateTimeKind.Local).AddTicks(9503));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 15, 42, 16, 307, DateTimeKind.Local).AddTicks(5698));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7e5d5379-9f9e-4bf6-9744-7623008c998d"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 15, 42, 16, 307, DateTimeKind.Local).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 15, 42, 16, 307, DateTimeKind.Local).AddTicks(5712));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 13, 40, 25, 90, DateTimeKind.Local).AddTicks(2111));

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 13, 40, 25, 90, DateTimeKind.Local).AddTicks(2150));

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 13, 40, 25, 87, DateTimeKind.Local).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 13, 40, 25, 90, DateTimeKind.Local).AddTicks(3980));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7e5d5379-9f9e-4bf6-9744-7623008c998d"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 13, 40, 25, 90, DateTimeKind.Local).AddTicks(3241));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 13, 40, 25, 90, DateTimeKind.Local).AddTicks(3993));
        }
    }
}
