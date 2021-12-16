using Microsoft.EntityFrameworkCore.Migrations;

namespace DominicsPizza.Repositories.Migrations
{
    public partial class UpdateCartModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Carts",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Carts",
                newName: "guid");
        }
    }
}
