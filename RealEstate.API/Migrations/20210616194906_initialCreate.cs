using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.API.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YearOfConstruction = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AverageRating = table.Column<double>(type: "float", nullable: false),
                    TotalComments = table.Column<int>(type: "int", nullable: false),
                    TotalRealEstates = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Advertisments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellingPrice = table.Column<int>(type: "int", nullable: false),
                    RentingPrice = table.Column<int>(type: "int", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyType = table.Column<int>(type: "int", nullable: false),
                    CanBeSold = table.Column<bool>(type: "bit", nullable: false),
                    CanBeRented = table.Column<bool>(type: "bit", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertisments_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advertisments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    WrittenByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserToWriteAboutId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserToWriteAboutId",
                        column: x => x.UserToWriteAboutId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Ratings_Users_WrittenByUserId",
                        column: x => x.WrittenByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdvertismentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Advertisments_AdvertismentId",
                        column: x => x.AdvertismentId,
                        principalTable: "Advertisments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "YearOfConstruction" },
                values: new object[] { new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"), "Sveavägen 12, Stockholm", 1978 });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "YearOfConstruction" },
                values: new object[] { new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"), "Drottninggatan 4, Göteborg", 2002 });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "YearOfConstruction" },
                values: new object[] { new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"), "Stora Torg 9, Malmö", 1999 });

            migrationBuilder.InsertData(
                table: "Advertisments",
                columns: new[] { "Id", "CanBeRented", "CanBeSold", "Contact", "CreatedOn", "Description", "PropertyId", "PropertyType", "RentingPrice", "SellingPrice", "Title", "UserId" },
                values: new object[] { new Guid("eff86b15-4872-4c8d-ac32-bf351fb71a2c"), true, false, "0888-888-888", new DateTime(2021, 6, 16, 21, 49, 5, 736, DateTimeKind.Local).AddTicks(4715), "Med våra modernt ljudisolerade fönster hör du inget av det blodiga gängkring som just nu skördar liv i Malmös innerstad", new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"), 2, 1000, 10000000, "Skaplig trea i Malmö centrum", null });

            migrationBuilder.InsertData(
                table: "Advertisments",
                columns: new[] { "Id", "CanBeRented", "CanBeSold", "Contact", "CreatedOn", "Description", "PropertyId", "PropertyType", "RentingPrice", "SellingPrice", "Title", "UserId" },
                values: new object[] { new Guid("bb628a76-25b3-451d-9998-d2406ef6e4b7"), true, false, "0888-888-888", new DateTime(2021, 6, 16, 21, 49, 5, 736, DateTimeKind.Local).AddTicks(4682), "Njut av kvällssolen på den fina balkongen i denna fina och ytsmarta lägenhet i hjärtat av Göteborg", new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"), 3, 1000, 10000000, "Rymlig etta mitt i Göteborg", null });

            migrationBuilder.InsertData(
                table: "Advertisments",
                columns: new[] { "Id", "CanBeRented", "CanBeSold", "Contact", "CreatedOn", "Description", "PropertyId", "PropertyType", "RentingPrice", "SellingPrice", "Title", "UserId" },
                values: new object[] { new Guid("bb9935ca-5f28-4db1-96a0-4c5a1e3cc692"), true, false, "0888-888-888", new DateTime(2021, 6, 16, 21, 49, 5, 734, DateTimeKind.Local).AddTicks(865), "Välkomna till denna vackra lägenhet i centrala Stockholm med två sovrum och stort kök", new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"), 1, 1000, 10000000, "Vacker tvåa på Sveavägen", null });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AdvertismentId", "Content", "CreatedOn", "UserId" },
                values: new object[] { new Guid("acbcb3d5-64e2-420b-93c7-99d3435377f9"), new Guid("eff86b15-4872-4c8d-ac32-bf351fb71a2c"), "Bra pris.", new DateTime(2021, 6, 16, 21, 49, 5, 736, DateTimeKind.Local).AddTicks(6953), null });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AdvertismentId", "Content", "CreatedOn", "UserId" },
                values: new object[] { new Guid("b2aa2881-9021-4d91-88ff-8f452dccc105"), new Guid("bb628a76-25b3-451d-9998-d2406ef6e4b7"), "Väldigt fint läge.", new DateTime(2021, 6, 16, 21, 49, 5, 736, DateTimeKind.Local).AddTicks(6940), null });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AdvertismentId", "Content", "CreatedOn", "UserId" },
                values: new object[] { new Guid("c30141ec-acfa-4a5f-8869-c1fedcc410be"), new Guid("bb9935ca-5f28-4db1-96a0-4c5a1e3cc692"), "Dålig utsikt!!", new DateTime(2021, 6, 16, 21, 49, 5, 736, DateTimeKind.Local).AddTicks(5835), null });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisments_PropertyId",
                table: "Advertisments",
                column: "PropertyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Advertisments_UserId",
                table: "Advertisments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AdvertismentId",
                table: "Comments",
                column: "AdvertismentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserToWriteAboutId",
                table: "Ratings",
                column: "UserToWriteAboutId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_WrittenByUserId",
                table: "Ratings",
                column: "WrittenByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Advertisments");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
