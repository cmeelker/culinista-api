using Microsoft.EntityFrameworkCore.Migrations;

namespace Culinista.Migrations
{
    public partial class AddImageAndUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Recipe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Recipe",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "Recipe");
        }
    }
}
