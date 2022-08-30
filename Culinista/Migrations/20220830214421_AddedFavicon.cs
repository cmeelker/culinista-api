using Microsoft.EntityFrameworkCore.Migrations;

namespace Culinista.Migrations
{
    public partial class AddedFavicon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Favicon",
                table: "Recipe",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favicon",
                table: "Recipe");
        }
    }
}
