using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.Migrations
{
    public partial class AddNombreColumnToTipoMembresiaEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "TipoMembresia",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "TipoMembresia");
        }
    }
}
