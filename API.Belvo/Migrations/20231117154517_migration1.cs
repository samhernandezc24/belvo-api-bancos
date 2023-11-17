using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Belvo.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    IdLink = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Institucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModoAcceso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimoAccesoFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioInstitucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkEstatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TasaActualizacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlmacenamientoCredenciales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuscarRecursos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkVencimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.IdLink);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    IdCuenta = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdLink = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InstitucionNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitucionTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitucionCodigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecoleccionFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CuentaCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaTipoSaldo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaAgencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaldoActual = table.Column<decimal>(type: "decimal(30,2)", nullable: false),
                    SaldoDisponible = table.Column<decimal>(type: "decimal(30,2)", nullable: false),
                    MonedaCodigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaIdentificacionPublicaNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaIdentificacionPublicaValor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimoAccesoFecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreditoLimite = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CreditoRecoleccionFecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreditoCorteFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditoProximoPagoFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditoPagoMinimo = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CreditoPagoSinInteres = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CreditoTasaInteres = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CreditoPagoMensual = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CreditoUltimoPagoFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditoSaldoUltimoPeriodo = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    PrestamoRecoleccionFecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrestamoMontoContrato = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    PrestamoPrincipal = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    PrestamoTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoDiaPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoPrincipalPendientePago = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    PrestamoSaldoPendientePago = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    PrestamoPagoMensual = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    PrestamoTasaInteresJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoTarifaJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoNumeroCuotasTotal = table.Column<int>(type: "int", nullable: true),
                    PrestamoNumeroCuotasPendientes = table.Column<int>(type: "int", nullable: true),
                    PrestamoContratoInicioFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoContratoFinalizacionFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoNumeroContrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoDiaCorte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoCorteFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoUltimoPagoFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoPagoSinInteres = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    FondosRecoleccionFecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FondosNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FondosTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FondosIdentificacionPublicaJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FondosSaldo = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    FondosPorcentaje = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CuentasPorCobrarActual = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CuentasPorCobrarDisponible = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CuentasPorCobrarAnticipado = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CuentasPorCobrarRecoleccionFecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdProductoBancario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaIdentificacionInterna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.IdCuenta);
                    table.ForeignKey(
                        name: "FK_Cuentas_Links_IdLink",
                        column: x => x.IdLink,
                        principalTable: "Links",
                        principalColumn: "IdLink",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    IdTransaccion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TransaccionIdentificacionInterna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCuenta = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdLink = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdCuentaProductoBancario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecoleccionFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransaccionValorFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransaccionContableFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransaccionMonto = table.Column<decimal>(type: "decimal(30,2)", nullable: false),
                    TransaccionSaldo = table.Column<decimal>(type: "decimal(30,2)", nullable: false),
                    MonedaCodigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransaccionDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransaccionObservaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComercianteNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransaccionCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransaccionSubCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransaccionReferencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransaccionTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransaccionEstatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetaCreditoRecoleccionFecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TarjetaCreditoFacturaNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetaCreditoFacturaEstatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetaCreditoFacturaMonto = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    TarjetaCreditoTotalFacturaAnterior = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.IdTransaccion);
                    table.ForeignKey(
                        name: "FK_Transacciones_Cuentas_IdCuenta",
                        column: x => x.IdCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "IdCuenta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transacciones_Links_IdLink",
                        column: x => x.IdLink,
                        principalTable: "Links",
                        principalColumn: "IdLink",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_IdLink",
                table: "Cuentas",
                column: "IdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_IdCuenta",
                table: "Transacciones",
                column: "IdCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_IdLink",
                table: "Transacciones",
                column: "IdLink");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Links");
        }
    }
}
