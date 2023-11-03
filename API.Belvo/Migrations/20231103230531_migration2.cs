using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Belvo.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FondosIdentificacionPublicaNombre",
                table: "Cuentas");

            migrationBuilder.RenameColumn(
                name: "FondosIdentificacionPublicaValor",
                table: "Cuentas",
                newName: "FondosIdentificacionPublicaJson");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FondosIdentificacionPublicaJson",
                table: "Cuentas",
                newName: "FondosIdentificacionPublicaValor");

            migrationBuilder.AddColumn<string>(
                name: "FondosIdentificacionPublicaNombre",
                table: "Cuentas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
