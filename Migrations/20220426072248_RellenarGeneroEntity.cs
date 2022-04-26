using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.Migrations
{
    public partial class RellenarGeneroEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Genero (Id, Nombre) values (1, 'Comedia')");
            migrationBuilder.Sql("Insert into Genero (Id, Nombre) values (2, 'Acción')");
            migrationBuilder.Sql("Insert into Genero (Id, Nombre) values (3, 'Terror')");
            migrationBuilder.Sql("Insert into Genero (Id, Nombre) values (4, 'Drama')");
            migrationBuilder.Sql("Insert into Genero (Id, Nombre) values (5, 'Ciencia-Ficción')");
            migrationBuilder.Sql("Insert into Genero (Id, Nombre) values (6, 'Fantasía')");
            migrationBuilder.Sql("Insert into Genero (Id, Nombre) values (7, 'Musical')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete * From Genero Where Id in (1,2,3,4, 5, 6, 7)");
        }
    }
}
