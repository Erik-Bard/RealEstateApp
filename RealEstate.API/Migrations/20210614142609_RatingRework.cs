using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.API.Migrations.ApplicationDb
{
    public partial class RatingRework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValueSql: "newsequentialid()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
