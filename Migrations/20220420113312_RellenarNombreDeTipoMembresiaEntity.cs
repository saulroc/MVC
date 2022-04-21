using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.Migrations
{
    public partial class RellenarNombreDeTipoMembresiaEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Update TipoMembresia Set Nombre = 'Pago por uso' Where Id = 1");
            migrationBuilder.Sql("Update TipoMembresia Set Nombre = 'Mensual' Where Id = 2");
            migrationBuilder.Sql("Update TipoMembresia Set Nombre = 'Trimestral' Where Id = 3");
            migrationBuilder.Sql("Update TipoMembresia Set Nombre = 'Anual' Where Id = 4");
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
