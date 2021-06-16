using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.API.Migrations.Repository
{
    public partial class RatingRenameProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_AboutId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Ratings",
                newName: "WrittenByUserId");

            migrationBuilder.RenameColumn(
                name: "AboutId",
                table: "Ratings",
                newName: "UserToWriteAboutId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                newName: "IX_Ratings_WrittenByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_AboutId",
                table: "Ratings",
                newName: "IX_Ratings_UserToWriteAboutId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_UserToWriteAboutId",
                table: "Ratings",
                column: "UserToWriteAboutId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_WrittenByUserId",
                table: "Ratings",
                column: "WrittenByUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_UserToWriteAboutId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_WrittenByUserId",
                table: "Ratings");

            migrationBuilder.RenameColumn(
                name: "WrittenByUserId",
                table: "Ratings",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserToWriteAboutId",
                table: "Ratings",
                newName: "AboutId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_WrittenByUserId",
                table: "Ratings",
                newName: "IX_Ratings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_UserToWriteAboutId",
                table: "Ratings",
                newName: "IX_Ratings_AboutId");

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 17, 34, 3, 91, DateTimeKind.Local).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 17, 34, 3, 91, DateTimeKind.Local).AddTicks(549));

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 17, 34, 3, 88, DateTimeKind.Local).AddTicks(7784));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 17, 34, 3, 91, DateTimeKind.Local).AddTicks(2069));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7e5d5379-9f9e-4bf6-9744-7623008c998d"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 17, 34, 3, 91, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                column: "CreatedOn",
                value: new DateTime(2021, 6, 15, 17, 34, 3, 91, DateTimeKind.Local).AddTicks(2083));

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_AboutId",
                table: "Ratings",
                column: "AboutId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
