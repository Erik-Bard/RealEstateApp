using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.API.Migrations.Repository
{
    public partial class DoubleRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "AverageRating",
                table: "Users",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AverageRating",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 19, 1, 1, 680, DateTimeKind.Local).AddTicks(7388));

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 19, 1, 1, 680, DateTimeKind.Local).AddTicks(7419));

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 19, 1, 1, 678, DateTimeKind.Local).AddTicks(4591));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 19, 1, 1, 680, DateTimeKind.Local).AddTicks(8942));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7e5d5379-9f9e-4bf6-9744-7623008c998d"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 19, 1, 1, 680, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 19, 1, 1, 680, DateTimeKind.Local).AddTicks(8955));
        }
    }
}
