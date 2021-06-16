using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.API.Migrations.Repository
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Properties_PropertyId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"));

            migrationBuilder.DeleteData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"));

            migrationBuilder.DeleteData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7e5d5379-9f9e-4bf6-9744-7623008c998d"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"));

            migrationBuilder.RenameColumn(
                name: "PropertyId",
                table: "Comments",
                newName: "AdvertismentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_PropertyId",
                table: "Comments",
                newName: "IX_Comments_AdvertismentId");

            migrationBuilder.InsertData(
                table: "Advertisments",
                columns: new[] { "Id", "CanBeRented", "CanBeSold", "Contact", "CreatedOn", "Description", "PropertyId", "PropertyType", "RentingPrice", "SellingPrice", "Title" },
                values: new object[] { new Guid("bb9935ca-5f28-4db1-96a0-4c5a1e3cc692"), true, false, "0888-888-888", new DateTime(2021, 6, 16, 11, 56, 11, 642, DateTimeKind.Local).AddTicks(7817), "Välkomna till denna vackra lägenhet i centrala Stockholm med två sovrum och stort kök", new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"), 1, 1000, 10000000, "Vacker tvåa på Sveavägen" });

            migrationBuilder.InsertData(
                table: "Advertisments",
                columns: new[] { "Id", "CanBeRented", "CanBeSold", "Contact", "CreatedOn", "Description", "PropertyId", "PropertyType", "RentingPrice", "SellingPrice", "Title" },
                values: new object[] { new Guid("bb628a76-25b3-451d-9998-d2406ef6e4b7"), true, false, "0888-888-888", new DateTime(2021, 6, 16, 11, 56, 11, 645, DateTimeKind.Local).AddTicks(1140), "Njut av kvällssolen på den fina balkongen i denna fina och ytsmarta lägenhet i hjärtat av Göteborg", new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"), 3, 1000, 10000000, "Rymlig etta mitt i Göteborg" });

            migrationBuilder.InsertData(
                table: "Advertisments",
                columns: new[] { "Id", "CanBeRented", "CanBeSold", "Contact", "CreatedOn", "Description", "PropertyId", "PropertyType", "RentingPrice", "SellingPrice", "Title" },
                values: new object[] { new Guid("eff86b15-4872-4c8d-ac32-bf351fb71a2c"), true, false, "0888-888-888", new DateTime(2021, 6, 16, 11, 56, 11, 645, DateTimeKind.Local).AddTicks(1174), "Med våra modernt ljudisolerade fönster hör du inget av det blodiga gängkring som just nu skördar liv i Malmös innerstad", new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"), 2, 1000, 10000000, "Skaplig trea i Malmö centrum" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AdvertismentId", "Content", "CreatedOn" },
                values: new object[] { new Guid("bb9935ca-5f28-4db1-96a0-4c5a1e3cc692"), new Guid("eff86b15-4872-4c8d-ac32-bf351fb71a2c"), "Dålig utsikt!!", new DateTime(2021, 6, 16, 11, 56, 11, 645, DateTimeKind.Local).AddTicks(2319) });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AdvertismentId", "Content", "CreatedOn" },
                values: new object[] { new Guid("bb628a76-25b3-451d-9998-d2406ef6e4b7"), new Guid("eff86b15-4872-4c8d-ac32-bf351fb71a2c"), "Väldigt fint läge.", new DateTime(2021, 6, 16, 11, 56, 11, 645, DateTimeKind.Local).AddTicks(3450) });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AdvertismentId", "Content", "CreatedOn" },
                values: new object[] { new Guid("3ed2d9cc-295d-4e46-a7fb-6d698cd36975"), new Guid("eff86b15-4872-4c8d-ac32-bf351fb71a2c"), "Bra pris.", new DateTime(2021, 6, 16, 11, 56, 11, 645, DateTimeKind.Local).AddTicks(3466) });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Advertisments_AdvertismentId",
                table: "Comments",
                column: "AdvertismentId",
                principalTable: "Advertisments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Advertisments_AdvertismentId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("bb628a76-25b3-451d-9998-d2406ef6e4b7"));

            migrationBuilder.DeleteData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("bb9935ca-5f28-4db1-96a0-4c5a1e3cc692"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("3ed2d9cc-295d-4e46-a7fb-6d698cd36975"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("bb628a76-25b3-451d-9998-d2406ef6e4b7"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("bb9935ca-5f28-4db1-96a0-4c5a1e3cc692"));

            migrationBuilder.DeleteData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: new Guid("eff86b15-4872-4c8d-ac32-bf351fb71a2c"));

            migrationBuilder.RenameColumn(
                name: "AdvertismentId",
                table: "Comments",
                newName: "PropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AdvertismentId",
                table: "Comments",
                newName: "IX_Comments_PropertyId");

            migrationBuilder.InsertData(
                table: "Advertisments",
                columns: new[] { "Id", "CanBeRented", "CanBeSold", "Contact", "CreatedOn", "Description", "PropertyId", "PropertyType", "RentingPrice", "SellingPrice", "Title" },
                values: new object[,]
                {
                    { new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"), true, false, "0888-888-888", new DateTime(2021, 6, 9, 21, 4, 55, 506, DateTimeKind.Local).AddTicks(2387), "Välkomna till denna vackra lägenhet i centrala Stockholm med två sovrum och stort kök", new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"), 1, 1000, 10000000, "Vacker tvåa på Sveavägen" },
                    { new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"), true, false, "0888-888-888", new DateTime(2021, 6, 9, 21, 4, 55, 508, DateTimeKind.Local).AddTicks(5317), "Njut av kvällssolen på den fina balkongen i denna fina och ytsmarta lägenhet i hjärtat av Göteborg", new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"), 3, 1000, 10000000, "Rymlig etta mitt i Göteborg" },
                    { new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"), true, false, "0888-888-888", new DateTime(2021, 6, 9, 21, 4, 55, 508, DateTimeKind.Local).AddTicks(5349), "Med våra modernt ljudisolerade fönster hör du inget av det blodiga gängkring som just nu skördar liv i Malmös innerstad", new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"), 2, 1000, 10000000, "Skaplig trea i Malmö centrum" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "PropertyId" },
                values: new object[,]
                {
                    { new Guid("7e5d5379-9f9e-4bf6-9744-7623008c998d"), "Dålig utsikt!!", new DateTime(2021, 6, 9, 21, 4, 55, 508, DateTimeKind.Local).AddTicks(6418), new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada") },
                    { new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"), "Väldigt fint läge.", new DateTime(2021, 6, 9, 21, 4, 55, 508, DateTimeKind.Local).AddTicks(7555), new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada") },
                    { new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"), "Bra pris.", new DateTime(2021, 6, 9, 21, 4, 55, 508, DateTimeKind.Local).AddTicks(7569), new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Properties_PropertyId",
                table: "Comments",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
