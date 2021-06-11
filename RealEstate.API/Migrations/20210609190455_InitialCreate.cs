using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.API.Migrations.Repository
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Advertisments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CanBeRented",
                table: "Advertisments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanBeSold",
                table: "Advertisments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Advertisments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Advertisments",
                type: "datetime2",
                maxLength: 1000,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "PropertyId",
                table: "Advertisments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "PropertyType",
                table: "Advertisments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RentingPrice",
                table: "Advertisments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SellingPrice",
                table: "Advertisments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                columns: new[] { "CanBeRented", "Contact", "CreatedOn", "PropertyId", "PropertyType", "RentingPrice", "SellingPrice" },
                values: new object[] { true, "0888-888-888", new DateTime(2021, 6, 9, 21, 4, 55, 508, DateTimeKind.Local).AddTicks(5317), new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"), 3, 1000, 10000000 });

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                columns: new[] { "CanBeRented", "Contact", "CreatedOn", "PropertyId", "PropertyType", "RentingPrice", "SellingPrice" },
                values: new object[] { true, "0888-888-888", new DateTime(2021, 6, 9, 21, 4, 55, 508, DateTimeKind.Local).AddTicks(5349), new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"), 2, 1000, 10000000 });

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"),
                columns: new[] { "CanBeRented", "Contact", "CreatedOn", "PropertyId", "PropertyType", "RentingPrice", "SellingPrice" },
                values: new object[] { true, "0888-888-888", new DateTime(2021, 6, 9, 21, 4, 55, 506, DateTimeKind.Local).AddTicks(2387), new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"), 1, 1000, 10000000 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "PropertyId" },
                values: new object[,]
                {
                    { new Guid("7e5d5379-9f9e-4bf6-9744-7623008c998d"), "Dålig utsikt!!", new DateTime(2021, 6, 9, 21, 4, 55, 508, DateTimeKind.Local).AddTicks(6418), new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada") },
                    { new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"), "Väldigt fint läge.", new DateTime(2021, 6, 9, 21, 4, 55, 508, DateTimeKind.Local).AddTicks(7555), new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada") },
                    { new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"), "Bra pris.", new DateTime(2021, 6, 9, 21, 4, 55, 508, DateTimeKind.Local).AddTicks(7569), new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisments_PropertyId",
                table: "Advertisments",
                column: "PropertyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PropertyId",
                table: "Comments",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisments_Properties_PropertyId",
                table: "Advertisments",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisments_Properties_PropertyId",
                table: "Advertisments");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Advertisments_PropertyId",
                table: "Advertisments");

            migrationBuilder.DropColumn(
                name: "CanBeRented",
                table: "Advertisments");

            migrationBuilder.DropColumn(
                name: "CanBeSold",
                table: "Advertisments");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Advertisments");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Advertisments");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Advertisments");

            migrationBuilder.DropColumn(
                name: "PropertyType",
                table: "Advertisments");

            migrationBuilder.DropColumn(
                name: "RentingPrice",
                table: "Advertisments");

            migrationBuilder.DropColumn(
                name: "SellingPrice",
                table: "Advertisments");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Advertisments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
