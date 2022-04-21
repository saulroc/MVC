using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.Migrations
{
    public partial class AddTipoDeMembresiaEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "TipoMembresiaId",
                table: "Clientes",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "TipoMembresia",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    TarifaDeRegistro = table.Column<short>(nullable: false),
                    DuracionEnMeses = table.Column<byte>(nullable: false),
                    Descuento = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMembresia", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_TipoMembresiaId",
                table: "Clientes",
                column: "TipoMembresiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_TipoMembresia_TipoMembresiaId",
                table: "Clientes",
                column: "TipoMembresiaId",
                principalTable: "TipoMembresia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_TipoMembresia_TipoMembresiaId",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "TipoMembresia");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_TipoMembresiaId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "TipoMembresiaId",
                table: "Clientes");
        }
    }
}
