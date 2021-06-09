using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.API.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertisments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YearOfConstruction = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Advertisments",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"), "Välkomna till denna vackra lägenhet i centrala Stockholm med två sovrum och stort kök", "Vacker tvåa på Sveavägen" },
                    { new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"), "Njut av kvällssolen på den fina balkongen i denna fina och ytsmarta lägenhet i hjärtat av Göteborg", "Rymlig etta mitt i Göteborg" },
                    { new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"), "Med våra modernt ljudisolerade fönster hör du inget av det blodiga gängkring som just nu skördar liv i Malmös innerstad", "Skaplig trea i Malmö centrum" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "YearOfConstruction" },
                values: new object[,]
                {
                    { new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"), "Sveavägen 12, Stockholm", 1978 },
                    { new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"), "Drottninggatan 4, Göteborg", 2002 },
                    { new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"), "Stora Torg 9, Malmö", 1999 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisments");

            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
