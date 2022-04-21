using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.Migrations
{
    public partial class RellenarTiposDeMembresia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into TipoMembresia (Id, TarifaDeRegistro, DuracionEnMeses, Descuento) values (1, 0, 0, 0)");
            migrationBuilder.Sql("Insert into TipoMembresia (Id, TarifaDeRegistro, DuracionEnMeses, Descuento) values (2, 30, 1, 10)");
            migrationBuilder.Sql("Insert into TipoMembresia (Id, TarifaDeRegistro, DuracionEnMeses, Descuento) values (3, 90, 3, 15)");
            migrationBuilder.Sql("Insert into TipoMembresia (Id, TarifaDeRegistro, DuracionEnMeses, Descuento) values (4, 300, 12, 20)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete * From TipoMembresia");
        }
    }
}
